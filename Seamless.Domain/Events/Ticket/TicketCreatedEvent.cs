using MediatR;
using System;

namespace Seamless.Domain.Events.Ticket
{
    public class TicketCreatedEvent : INotification
    {
        public Int64 TicketId { get; }

        public TicketCreatedEvent(Int64 ticketId)
        {
            TicketId = ticketId;
        }
    }
}