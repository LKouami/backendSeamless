using MediatR;

namespace Seamless.Domain.Events.NoteType
{
    public class NoteTypeDeletedEvent : INotification
    {
        public long NoteTypeId { get; }

        public NoteTypeDeletedEvent(long activityLogId)
        {
            NoteTypeId = activityLogId;
        }
    }
}