using MediatR;

namespace Seamless.Domain.Events.User
{
    public class UserDeletedEvent : INotification
    {
        public long UserId { get; }

        public UserDeletedEvent(long userId)
        {
            UserId = userId;
        }
    }
}