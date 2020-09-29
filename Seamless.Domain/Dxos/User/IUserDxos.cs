using Seamless.Domain.Commands.User;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IUserDxos : IBaseDxos
    {
        UserDto MapUserDto(AUser user);
        AUser MapCreateRequesttoUser(CreateUserCommand user);
        AUser MapUpdateRequesttoUser(UpdateUserCommand user);
    }
}
