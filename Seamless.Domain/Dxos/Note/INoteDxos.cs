using Seamless.Domain.Commands.Note;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface INoteDxos : IBaseDxos
    {
        NoteDto MapNoteDto(SNote note);
        SNote MapCreateRequesttoNote(CreateNoteCommand note);
        SNote MapUpdateRequesttoNote(UpdateNoteCommand note);
    }
}
