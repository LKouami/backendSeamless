using Seamless.Domain.Commands.AppParameter;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IAppParameterDxos : IBaseDxos
    {
        AppParameterDto MapAppParameterDto(SAppParameter appParameter);
        SAppParameter MapCreateRequesttoAppParameter(CreateAppParameterCommand appParameter);
        SAppParameter MapUpdateRequesttoAppParameter(UpdateAppParameterCommand appParameter);
    }
}
