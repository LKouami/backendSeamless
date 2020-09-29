using MediatR;
using System;

namespace Seamless.Domain.Events.Faq
{
    public class FaqCreatedEvent : INotification
    {
        public Int64 FaqId { get; }

        public FaqCreatedEvent(Int64 faqId)
        {
            FaqId = faqId;
        }
    }
}