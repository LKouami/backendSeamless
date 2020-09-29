using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Priority;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Priority;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeletePriorityHandler : IRequestHandler<DeletePriorityCommand, DeleteResult>
    {
        private readonly IPriorityRepository _priorityRepository;
        private readonly IMediator _mediator;

        public DeletePriorityHandler(IPriorityRepository priorityRepository,
            IMediator mediator)
        {
            _priorityRepository = priorityRepository ?? throw new ArgumentNullException(nameof(priorityRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
        {
            var priorityModel = await _priorityRepository.GetAsync(e => e.Id == request.Id);

            _priorityRepository.Remove(priorityModel);

            if (await _priorityRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new PriorityDeletedEvent(priorityModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}