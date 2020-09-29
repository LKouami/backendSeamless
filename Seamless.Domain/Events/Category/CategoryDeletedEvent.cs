using MediatR;

namespace Seamless.Domain.Events.Category
{
    public class CategoryDeletedEvent : INotification
    {
        public long CategoryId { get; }

        public CategoryDeletedEvent(long categoryId)
        {
            CategoryId = categoryId;
        }
    }
}