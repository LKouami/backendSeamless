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
    public class GetPriorityHandler : IRequestHandler<GetPriorityQuery, PriorityDto>
    {
        private readonly IPriorityRepository _priorityRepository;
        private readonly IPriorityDxos _priorityDxos;
        private readonly ILogger _logger;

        public GetPriorityHandler(IPriorityRepository priorityRepository, IPriorityDxos priorityDxos, ILogger<GetPriorityHandler> logger)
        {
            _priorityRepository = priorityRepository ?? throw new ArgumentNullException(nameof(priorityRepository));
            _priorityDxos = priorityDxos ?? throw new ArgumentNullException(nameof(priorityDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PriorityDto> Handle(GetPriorityQuery request, CancellationToken cancellationToken)
        {
            var priority = await _priorityRepository.GetAsync(e =>
                e.Id == request.Id);

            if (priority != null)
            {
                _logger.LogInformation($"Got a request get priority Id: {priority.Id}");
                var priorityDto = _priorityDxos.MapPriorityDto(priority);
                return priorityDto;
            }

            return null;
        }
    }
}