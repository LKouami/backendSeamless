using MediatR;
using System;

namespace Seamless.Domain.Events.Message
{
    public class MessageCreatedEvent : INotification
    {
        public Int64 MessageId { get; }

        public MessageCreatedEvent(Int64 messageId)
        {
            MessageId = messageId;
        }
    }
}