using MediatR;
using System;

namespace Seamless.Domain.Events.User
{
    public class UserCreatedEvent : INotification
    {
        public Int64 UserId { get; }

        public UserCreatedEvent(Int64 userId)
        {
            UserId = userId;
        }
    }
}