using MediatR;

namespace Seamless.Domain.Events.TicketStatus
{
    public class TicketStatusDeletedEvent : INotification
    {
        public long TicketStatusId { get; }

        public TicketStatusDeletedEvent(long ticketStatusId)
        {
            TicketStatusId = ticketStatusId;
        }
    }
}