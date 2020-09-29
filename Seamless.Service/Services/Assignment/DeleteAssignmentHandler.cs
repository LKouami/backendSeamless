using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Assignment;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Assignment;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteAssignmentHandler : IRequestHandler<DeleteAssignmentCommand, DeleteResult>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMediator _mediator;

        public DeleteAssignmentHandler(IAssignmentRepository assignmentRepository,
            IMediator mediator)
        {
            _assignmentRepository = assignmentRepository ?? throw new ArgumentNullException(nameof(assignmentRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var assignmentModel = await _assignmentRepository.GetAsync(e => e.Id == request.Id);

            _assignmentRepository.Remove(assignmentModel);

            if (await _assignmentRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new AssignmentDeletedEvent(assignmentModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}