using MediatR;

namespace Seamless.Domain.Events.Assignment
{
    public class AssignmentUpdatedEvent : INotification
    {
        public long AssignmentId { get; }

        public AssignmentUpdatedEvent(long assignmentId)
        {
            AssignmentId = assignmentId;
        }
    }
}