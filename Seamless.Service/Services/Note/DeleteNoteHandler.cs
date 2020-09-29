using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Note;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Note;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, DeleteResult>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMediator _mediator;

        public DeleteNoteHandler(INoteRepository noteRepository,
            IMediator mediator)
        {
            _noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var noteModel = await _noteRepository.GetAsync(e => e.Id == request.Id);

            _noteRepository.Remove(noteModel);

            if (await _noteRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new NoteDeletedEvent(noteModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}