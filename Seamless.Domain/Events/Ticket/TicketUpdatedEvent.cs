using MediatR;

namespace Seamless.Domain.Events.Ticket
{
    public class TicketUpdatedEvent : INotification
    {
        public long TicketId { get; }

        public TicketUpdatedEvent(long ticketId)
        {
            TicketId = ticketId;
        }
    }
}