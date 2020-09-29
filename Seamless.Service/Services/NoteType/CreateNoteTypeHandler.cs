using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.NoteType;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.NoteType;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class CreateNoteTypeHandler : IRequestHandler<CreateNoteTypeCommand, NoteTypeDto>
    {
        private readonly INoteTypeRepository _noteTypeRepository;
        private readonly INoteTypeDxos _noteTypeDxos;
        private readonly IMediator _mediator;

        public CreateNoteTypeHandler(INoteTypeRepository noteTypeRepository,
            IMediator mediator,
            INoteTypeDxos noteTypeDxos)
        {
            _noteTypeRepository = noteTypeRepository ?? throw new ArgumentNullException(nameof(noteTypeRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _noteTypeDxos = noteTypeDxos ?? throw new ArgumentNullException(nameof(noteTypeDxos));
        }


        public async Task<NoteTypeDto> Handle(CreateNoteTypeCommand request, CancellationToken cancellationToken)
        {
            var noteTypeModel = _noteTypeDxos.MapCreateRequesttoNoteType(request);

            _noteTypeRepository.Add(noteTypeModel);

            if (await _noteTypeRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new NoteTypeCreatedEvent(noteTypeModel.Id), cancellationToken);

            var noteTypeDto = _noteTypeDxos.MapNoteTypeDto(noteTypeModel);

            return noteTypeDto;
        }
    }
}