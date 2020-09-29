using MediatR;

namespace Seamless.Domain.Events.Faq
{
    public class FaqDeletedEvent : INotification
    {
        public long FaqId { get; }

        public FaqDeletedEvent(long faqId)
        {
            FaqId = faqId;
        }
    }
}