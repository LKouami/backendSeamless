using MediatR;
using System;

namespace Seamless.Domain.Events.TicketStatus
{
    public class TicketStatusCreatedEvent : INotification
    {
        public Int64 TicketStatusId { get; }

        public TicketStatusCreatedEvent(Int64 ticketStatusId)
        {
            TicketStatusId = ticketStatusId;
        }
    }
}