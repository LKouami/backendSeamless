using MediatR;

namespace Seamless.Domain.Events.TicketField
{
    public class TicketFieldDeletedEvent : INotification
    {
        public long TicketFieldId { get; }

        public TicketFieldDeletedEvent(long ticketFieldId)
        {
            TicketFieldId = ticketFieldId;
        }
    }
}