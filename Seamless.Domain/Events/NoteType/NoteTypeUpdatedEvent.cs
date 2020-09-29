using MediatR;

namespace Seamless.Domain.Events.NoteType
{
    public class NoteTypeUpdatedEvent : INotification
    {
        public long NoteTypeId { get; }

        public NoteTypeUpdatedEvent(long activityLogId)
        {
            NoteTypeId = activityLogId;
        }
    }
}