using MediatR;

namespace Seamless.Domain.Events.Message
{
    public class MessageUpdatedEvent : INotification
    {
        public long MessageId { get; }

        public MessageUpdatedEvent(long messageId)
        {
            MessageId = messageId;
        }
    }
}