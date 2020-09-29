using MediatR;

namespace Seamless.Domain.Events.Priority
{
    public class PriorityDeletedEvent : INotification
    {
        public long PriorityId { get; }

        public PriorityDeletedEvent(long priorityId)
        {
            PriorityId = priorityId;
        }
    }
}