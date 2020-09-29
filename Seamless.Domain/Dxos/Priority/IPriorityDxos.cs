using Seamless.Domain.Commands.Priority;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IPriorityDxos : IBaseDxos
    {
        PriorityDto MapPriorityDto(SPriority priority);
        SPriority MapCreateRequesttoPriority(CreatePriorityCommand priority);
        SPriority MapUpdateRequesttoPriority(UpdatePriorityCommand priority);
    }
}

