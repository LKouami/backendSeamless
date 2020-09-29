using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Assignment;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Assignment;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateAssignmentHandler : IRequestHandler<UpdateAssignmentCommand, AssignmentDto>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IAssignmentDxos _assignmentDxos;
        private readonly IMediator _mediator;

        public UpdateAssignmentHandler(IAssignmentRepository assignmentRepository,
            IMediator mediator,
            IAssignmentDxos assignmentDxos)
        {
            _assignmentRepository = assignmentRepository ?? throw new ArgumentNullException(nameof(assignmentRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _assignmentDxos = assignmentDxos ?? throw new ArgumentNullException(nameof(assignmentDxos));
        }


        public async Task<AssignmentDto> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            var assignmentModel = _assignmentDxos.MapUpdateRequesttoAssignment(request);

            _assignmentRepository.Update(assignmentModel);

            if (await _assignmentRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new AssignmentUpdatedEvent(assignmentModel.Id), cancellationToken);

            var assignmentDto = _assignmentDxos.MapAssignmentDto(assignmentModel);

            return assignmentDto;
        }
    }
}