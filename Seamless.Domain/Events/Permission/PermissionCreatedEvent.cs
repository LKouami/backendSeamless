using MediatR;
using System;

namespace Seamless.Domain.Events.Permission
{
    public class PermissionCreatedEvent : INotification
    {
        public Int64 PermissionId { get; }

        public PermissionCreatedEvent(Int64 activityLogId)
        {
            PermissionId = activityLogId;
        }
    }
}