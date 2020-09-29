using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.ActivityLog;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.ActivityLog;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteActivityLogHandler : IRequestHandler<DeleteActivityLogCommand, DeleteResult>
    {
        private readonly IActivityLogRepository _activityLogRepository;
        private readonly IMediator _mediator;

        public DeleteActivityLogHandler(IActivityLogRepository activityLogRepository,
            IMediator mediator)
        {
            _activityLogRepository = activityLogRepository ?? throw new ArgumentNullException(nameof(activityLogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteActivityLogCommand request, CancellationToken cancellationToken)
        {
            var activityLogModel = await _activityLogRepository.GetAsync(e => e.Id == request.Id);

            _activityLogRepository.Remove(activityLogModel);

            if (await _activityLogRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new ActivityLogDeletedEvent(activityLogModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}