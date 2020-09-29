using MediatR;
using System;

namespace Seamless.Domain.Events.TicketField
{
    public class TicketFieldCreatedEvent : INotification
    {
        public Int64 TicketFieldId { get; }

        public TicketFieldCreatedEvent(Int64 ticketFieldId)
        {
            TicketFieldId = ticketFieldId;
        }
    }
}