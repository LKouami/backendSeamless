using MediatR;
using System;

namespace Seamless.Domain.Events.NoteType
{
    public class NoteTypeCreatedEvent : INotification
    {
        public Int64 NoteTypeId { get; }

        public NoteTypeCreatedEvent(Int64 activityLogId)
        {
            NoteTypeId = activityLogId;
        }
    }
}