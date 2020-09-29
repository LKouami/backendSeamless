using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Note;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Note;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, NoteDto>
    {
        private readonly INoteRepository _noteRepository;
        private readonly INoteDxos _noteDxos;
        private readonly IMediator _mediator;

        public UpdateNoteHandler(INoteRepository noteRepository,
            IMediator mediator,
            INoteDxos noteDxos)
        {
            _noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _noteDxos = noteDxos ?? throw new ArgumentNullException(nameof(noteDxos));
        }


        public async Task<NoteDto> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteModel = _noteDxos.MapUpdateRequesttoNote(request);

            _noteRepository.Update(noteModel);

            if (await _noteRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new NoteUpdatedEvent(noteModel.Id), cancellationToken);

            var noteDto = _noteDxos.MapNoteDto(noteModel);

            return noteDto;
        }
    }
}