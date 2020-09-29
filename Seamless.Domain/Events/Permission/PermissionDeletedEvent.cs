using MediatR;

namespace Seamless.Domain.Events.Permission
{
    public class PermissionDeletedEvent : INotification
    {
        public long PermissionId { get; }

        public PermissionDeletedEvent(long activityLogId)
        {
            PermissionId = activityLogId;
        }
    }
}