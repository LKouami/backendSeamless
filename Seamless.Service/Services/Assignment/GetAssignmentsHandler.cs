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
    public class GetAssignmentsHandler : IRequestHandler<GetAssignmentsQuery, PagedResults<AssignmentDto>>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly ILogger _logger;

        public GetAssignmentsHandler(IAssignmentRepository assignmentRepository, IAssignmentDxos assignmentDxos,
            ILogger<GetAssignmentsHandler> logger)
        {
            _assignmentRepository = assignmentRepository ?? throw new ArgumentNullException(nameof(assignmentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<AssignmentDto>> Handle(GetAssignmentsQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _assignmentRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _assignmentRepository.GetListPageAsync(request, null);
            }

        }
    }
}