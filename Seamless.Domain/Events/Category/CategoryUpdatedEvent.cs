using MediatR;

namespace Seamless.Domain.Events.Category
{
    public class CategoryUpdatedEvent : INotification
    {
        public long CategoryId { get; }

        public CategoryUpdatedEvent(long categoryId)
        {
            CategoryId = categoryId;
        }
    }
}