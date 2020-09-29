using Seamless.Domain.Commands.Ticket;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface ITicketDxos : IBaseDxos
    {
        TicketDto MapTicketDto(STicket ticket);
        STicket MapCreateRequesttoTicket(CreateTicketCommand ticket);
        STicket MapUpdateRequesttoTicket(UpdateTicketCommand ticket);
    }
}
