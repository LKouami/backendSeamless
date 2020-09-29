using Seamless.Domain.Commands.Message;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IMessageDxos : IBaseDxos
    {
        MessageDto MapMessageDto(SMessage message);
        SMessage MapCreateRequesttoMessage(CreateMessageCommand message);
        SMessage MapUpdateRequesttoMessage(UpdateMessageCommand message);
    }
}
