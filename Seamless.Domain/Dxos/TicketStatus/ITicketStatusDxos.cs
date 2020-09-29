using Seamless.Domain.Commands.TicketStatus;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface ITicketStatusDxos : IBaseDxos
    {
        TicketStatusDto MapTicketStatusDto(STicketStatus ticketStatus);
        STicketStatus MapCreateRequesttoTicketStatus(CreateTicketStatusCommand ticketStatus);
        STicketStatus MapUpdateRequesttoTicketStatus(UpdateTicketStatusCommand ticketStatus);
    }
}
