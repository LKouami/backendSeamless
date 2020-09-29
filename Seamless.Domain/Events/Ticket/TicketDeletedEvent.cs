using MediatR;

namespace Seamless.Domain.Events.Ticket
{
    public class TicketDeletedEvent : INotification
    {
        public long TicketId { get; }

        public TicketDeletedEvent(long ticketId)
        {
            TicketId = ticketId;
        }
    }
}