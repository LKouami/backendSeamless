using MediatR;
using System;

namespace Seamless.Domain.Events.Assignment
{
    public class AssignmentCreatedEvent : INotification
    {
        public Int64 AssignmentId { get; }

        public AssignmentCreatedEvent(Int64 assignmentId)
        {
            AssignmentId = assignmentId;
        }
    }
}