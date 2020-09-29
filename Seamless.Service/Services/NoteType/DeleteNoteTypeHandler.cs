using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.NoteType;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.NoteType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteNoteTypeHandler : IRequestHandler<DeleteNoteTypeCommand, DeleteResult>
    {
        private readonly INoteTypeRepository _noteTypeRepository;
        private readonly IMediator _mediator;

        public DeleteNoteTypeHandler(INoteTypeRepository noteTypeRepository,
            IMediator mediator)
        {
            _noteTypeRepository = noteTypeRepository ?? throw new ArgumentNullException(nameof(noteTypeRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteNoteTypeCommand request, CancellationToken cancellationToken)
        {
            var noteTypeModel = await _noteTypeRepository.GetAsync(e => e.Id == request.Id);

            _noteTypeRepository.Remove(noteTypeModel);

            if (await _noteTypeRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new NoteTypeDeletedEvent(noteTypeModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}