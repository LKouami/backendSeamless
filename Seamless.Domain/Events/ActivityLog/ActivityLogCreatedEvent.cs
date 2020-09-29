using MediatR;
using System;

namespace Seamless.Domain.Events.ActivityLog
{
    public class ActivityLogCreatedEvent : INotification
    {
        public Int64 ActivityLogId { get; }

        public ActivityLogCreatedEvent(Int64 activityLogId)
        {
            ActivityLogId = activityLogId;
        }
    }
}