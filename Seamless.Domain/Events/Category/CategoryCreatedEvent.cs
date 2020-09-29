using MediatR;
using System;

namespace Seamless.Domain.Events.Category
{
    public class CategoryCreatedEvent : INotification
    {
        public Int64 CategoryId { get; }

        public CategoryCreatedEvent(Int64 categoryId)
        {
            CategoryId = categoryId;
        }
    }
}