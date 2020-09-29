using MediatR;

namespace Seamless.Domain.Events.AppParameter
{
    public class AppParameterDeletedEvent : INotification
    {
        public long AppParameterId { get; }

        public AppParameterDeletedEvent(long appParameterId)
        {
            AppParameterId = appParameterId;
        }
    }
}