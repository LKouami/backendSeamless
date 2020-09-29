using MediatR;

namespace Seamless.Domain.Events.Note
{
    public class NoteDeletedEvent : INotification
    {
        public long NoteId { get; }

        public NoteDeletedEvent(long noteId)
        {
            NoteId = noteId;
        }
    }
}