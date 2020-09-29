using MediatR;

namespace Seamless.Domain.Events.TicketStatus
{
    public class TicketStatusUpdatedEvent : INotification
    {
        public long TicketStatusId { get; }

        public TicketStatusUpdatedEvent(long ticketStatusId)
        {
            TicketStatusId = ticketStatusId;
        }
    }
}