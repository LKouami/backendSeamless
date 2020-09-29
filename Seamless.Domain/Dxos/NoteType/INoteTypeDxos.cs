using Seamless.Domain.Commands.NoteType;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface INoteTypeDxos : IBaseDxos
    {
        NoteTypeDto MapNoteTypeDto(SNoteType noteType);
        SNoteType MapCreateRequesttoNoteType(CreateNoteTypeCommand noteType);
        SNoteType MapUpdateRequesttoNoteType(UpdateNoteTypeCommand noteType);
    }
}
