using MediatR;

namespace Seamless.Domain.Events.ActivityLog
{
    public class ActivityLogDeletedEvent : INotification
    {
        public long ActivityLogId { get; }

        public ActivityLogDeletedEvent(long activityLogId)
        {
            ActivityLogId = activityLogId;
        }
    }
}