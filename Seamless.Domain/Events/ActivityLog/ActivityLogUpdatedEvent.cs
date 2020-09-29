using MediatR;

namespace Seamless.Domain.Events.ActivityLog
{
    public class ActivityLogUpdatedEvent : INotification
    {
        public long ActivityLogId { get; }

        public ActivityLogUpdatedEvent(long activityLogId)
        {
            ActivityLogId = activityLogId;
        }
    }
}