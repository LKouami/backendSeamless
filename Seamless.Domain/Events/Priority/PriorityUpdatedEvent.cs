using MediatR;

namespace Seamless.Domain.Events.Priority
{
    public class PriorityUpdatedEvent : INotification
    {
        public long PriorityId { get; }

        public PriorityUpdatedEvent(long priorityId)
        {
            PriorityId = priorityId;
        }
    }
}