using MediatR;
using System;

namespace Seamless.Domain.Events.Note
{
    public class NoteCreatedEvent : INotification
    {
        public Int64 NoteId { get; }

        public NoteCreatedEvent(Int64 noteId)
        {
            NoteId = noteId;
        }
    }
}