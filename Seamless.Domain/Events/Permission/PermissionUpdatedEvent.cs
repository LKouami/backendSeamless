using MediatR;

namespace Seamless.Domain.Events.Permission
{
    public class PermissionUpdatedEvent : INotification
    {
        public long PermissionId { get; }

        public PermissionUpdatedEvent(long activityLogId)
        {
            PermissionId = activityLogId;
        }
    }
}