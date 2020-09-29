using MediatR;
using System;

namespace Seamless.Domain.Events.Priority
{
    public class PriorityCreatedEvent : INotification
    {
        public Int64 PriorityId { get; }

        public PriorityCreatedEvent(Int64 priorityId)
        {
            PriorityId = priorityId;
        }
    }
}