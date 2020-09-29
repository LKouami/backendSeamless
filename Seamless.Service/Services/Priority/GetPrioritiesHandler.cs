using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Priority;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetPrioritiesHandler : IRequestHandler<GetPrioritiesQuery, PagedResults<PriorityDto>>
    {
        private readonly IPriorityRepository _priorityRepository;
        private readonly ILogger _logger;

        public GetPrioritiesHandler(IPriorityRepository priorityRepository, IPriorityDxos priorityDxos,
            ILogger<GetPrioritiesHandler> logger)
        {
            _priorityRepository = priorityRepository ?? throw new ArgumentNullException(nameof(priorityRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<PriorityDto>> Handle(GetPrioritiesQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _priorityRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _priorityRepository.GetListPageAsync(request,
               p =>
                   p.Name.ToLower().StartsWith(request.Search));
            }

        }
    }
}