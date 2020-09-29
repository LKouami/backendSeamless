using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IRoleDxos: IBaseDxos
    {
        RoleDto MapRoleDto(ARole employee);
        //ARole MapCreateRequesttoRole(CreateRoleCommand employee);
        //ARole MapUpdateRequesttoRole(UpdateRoleCommand employee);
    }
}