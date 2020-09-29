using Seamless.Domain.Commands.TicketField;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface ITicketFieldDxos : IBaseDxos
    {
        TicketFieldDto MapTicketFieldDto(STicketField ticketField);
        STicketField MapCreateRequesttoTicketField(CreateTicketFieldCommand ticketField);
        STicketField MapUpdateRequesttoTicketField(UpdateTicketFieldCommand ticketField);
    }
}
