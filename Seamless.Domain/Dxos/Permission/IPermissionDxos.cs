using Seamless.Domain.Commands.Permission;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IPermissionDxos : IBaseDxos
    {
        PermissionDto MapPermissionDto(SPermission permission);
        SPermission MapCreateRequesttoPermission(CreatePermissionCommand permission);
        SPermission MapUpdateRequesttoPermission(UpdatePermissionCommand permission);
    }
}
