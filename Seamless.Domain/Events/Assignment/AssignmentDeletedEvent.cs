using MediatR;

namespace Seamless.Domain.Events.Assignment
{
    public class AssignmentDeletedEvent : INotification
    {
        public long AssignmentId { get; }

        public AssignmentDeletedEvent(long assignmentId)
        {
            AssignmentId = assignmentId;
        }
    }
}