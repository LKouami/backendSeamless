using MediatR;

namespace Seamless.Domain.Events.Message
{
    public class MessageDeletedEvent : INotification
    {
        public long MessageId { get; }

        public MessageDeletedEvent(long messageId)
        {
            MessageId = messageId;
        }
    }
}