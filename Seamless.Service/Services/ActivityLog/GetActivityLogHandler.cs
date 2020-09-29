using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.ActivityLog;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetActivityLogHandler : IRequestHandler<GetActivityLogQuery, ActivityLogDto>
    {
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly IActivityLogDxos _activityLogDxos;
        private readonly ILogger _logger;

        public GetActivityLogHandler(IActivityLogRepository activityLogRepository, IActivityLogDxos activityLogDxos, ILogger<GetActivityLogHandler> logger)
        {
            _activityLogRepository = activityLogRepository ?? throw new ArgumentNullException(nameof(activityLogRepository));
            _activityLogDxos = activityLogDxos ?? throw new ArgumentNullException(nameof(activityLogDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ActivityLogDto> Handle(GetActivityLogQuery request, CancellationToken cancellationToken)
        {
            var activityLog = await _activityLogRepository.GetAsync(e =>
                e.Id == request.Id);

            if (activityLog != null)
            {
                _logger.LogInformation($"Got a request get activityLog Id: {activityLog.Id}");
                var activityLogDto = _activityLogDxos.MapActivityLogDto(activityLog);
                return activityLogDto;
            }

            return null;
        }
    }
}