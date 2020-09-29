using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Assignment;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetAssignmentHandler : IRequestHandler<GetAssignmentQuery, AssignmentDto>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IAssignmentDxos _assignmentDxos;
        private readonly ILogger _logger;

        public GetAssignmentHandler(IAssignmentRepository assignmentRepository, IAssignmentDxos assignmentDxos, ILogger<GetAssignmentHandler> logger)
        {
            _assignmentRepository = assignmentRepository ?? throw new ArgumentNullException(nameof(assignmentRepository));
            _assignmentDxos = assignmentDxos ?? throw new ArgumentNullException(nameof(assignmentDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AssignmentDto> Handle(GetAssignmentQuery request, CancellationToken cancellationToken)
        {
            var assignment = await _assignmentRepository.GetAsync(e =>
                e.Id == request.Id);

            if (assignment != null)
            {
                _logger.LogInformation($"Got a request get assignment Id: {assignment.Id}");
                var assignmentDto = _assignmentDxos.MapAssignmentDto(assignment);
                return assignmentDto;
            }

            return null;
        }
    }
}