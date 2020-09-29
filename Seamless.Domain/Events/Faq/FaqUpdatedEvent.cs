using MediatR;

namespace Seamless.Domain.Events.Faq
{
    public class FaqUpdatedEvent : INotification
    {
        public long FaqId { get; }

        public FaqUpdatedEvent(long faqId)
        {
            FaqId = faqId;
        }
    }
}