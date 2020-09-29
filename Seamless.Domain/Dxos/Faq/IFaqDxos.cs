using Seamless.Domain.Commands.Faq;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface IFaqDxos : IBaseDxos
    {
        FaqDto MapFaqDto(SFaq faq);
        SFaq MapCreateRequesttoFaq(CreateFaqCommand faq);
        SFaq MapUpdateRequesttoFaq(UpdateFaqCommand faq);
    }
}
