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
    public class CreateActivityLogHandler : IRequestHandler<CreateActivityLogCommand, ActivityLogDto>
    {
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly IActivityLogDxos _activityLogDxos;
        private readonly IMediator _mediator;

        public CreateActivityLogHandler(IActivityLogRepository activityLogRepository,
            IMediator mediator,
            IActivityLogDxos activityLogDxos)
        {
            _activityLogRepository = activityLogRepository ?? throw new ArgumentNullException(nameof(activityLogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _activityLogDxos = activityLogDxos ?? throw new ArgumentNullException(nameof(activityLogDxos));
        }


        public async Task<ActivityLogDto> Handle(CreateActivityLogCommand request, CancellationToken cancellationToken)
        {
            var activityLogModel = _activityLogDxos.MapCreateRequesttoActivityLog(request);

            _activityLogRepository.Add(activityLogModel);

            if (await _activityLogRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new ActivityLogCreatedEvent(activityLogModel.Id), cancellationToken);

            var activityLogDto = _activityLogDxos.MapActivityLogDto(activityLogModel);

            return activityLogDto;
        }
    }
}