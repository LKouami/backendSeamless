using MediatR;
using System;

namespace Seamless.Domain.Events.AppParameter
{
    public class AppParameterCreatedEvent : INotification
    {
        public Int64 AppParameterId { get; }

        public AppParameterCreatedEvent(Int64 appParameterId)
        {
            AppParameterId = appParameterId;
        }
    }
}