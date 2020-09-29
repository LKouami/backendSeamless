using MediatR;

namespace Seamless.Domain.Events.Note
{
    public class NoteUpdatedEvent : INotification
    {
        public long NoteId { get; }

        public NoteUpdatedEvent(long noteId)
        {
            NoteId = noteId;
        }
    }
}