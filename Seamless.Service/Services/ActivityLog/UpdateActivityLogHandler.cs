using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.ActivityLog;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.ActivityLog;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateActivityLogHandler : IRequestHandler<UpdateActivityLogCommand, ActivityLogDto>
    {
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly IActivityLogDxos _activityLogDxos;
        private readonly IMediator _mediator;

        public UpdateActivityLogHandler(IActivityLogRepository activityLogRepository,
            IMediator mediator,
            IActivityLogDxos activityLogDxos)
        {
            _activityLogRepository = activityLogRepository ?? throw new ArgumentNullException(nameof(activityLogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _activityLogDxos = activityLogDxos ?? throw new ArgumentNullException(nameof(activityLogDxos));
        }


        public async Task<ActivityLogDto> Handle(UpdateActivityLogCommand request, CancellationToken cancellationToken)
        {
            var activityLogModel = _activityLogDxos.MapUpdateRequesttoActivityLog(request);

            _activityLogRepository.Update(activityLogModel);

            if (await _activityLogRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new ActivityLogUpdatedEvent(activityLogModel.Id), cancellationToken);

            var activityLogDto = _activityLogDxos.MapActivityLogDto(activityLogModel);

            return activityLogDto;
        }
    }
}