using MediatR;

namespace Seamless.Domain.Events.TicketField
{
    public class TicketFieldUpdatedEvent : INotification
    {
        public long TicketFieldId { get; }

        public TicketFieldUpdatedEvent(long ticketFieldId)
        {
            TicketFieldId = ticketFieldId;
        }
    }
}