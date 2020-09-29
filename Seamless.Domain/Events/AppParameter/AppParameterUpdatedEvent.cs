using MediatR;

namespace Seamless.Domain.Events.AppParameter
{
    public class AppParameterUpdatedEvent : INotification
    {
        public long AppParameterId { get; }

        public AppParameterUpdatedEvent(long appParameterId)
        {
            AppParameterId = appParameterId;
        }
    }
}