using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Note;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetNoteHandler : IRequestHandler<GetNoteQuery, NoteDto>
    {
        private readonly INoteRepository _noteRepository;
        private readonly INoteDxos _noteDxos;
        private readonly ILogger _logger;

        public GetNoteHandler(INoteRepository noteRepository, INoteDxos noteDxos, ILogger<GetNoteHandler> logger)
        {
            _noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
            _noteDxos = noteDxos ?? throw new ArgumentNullException(nameof(noteDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<NoteDto> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var note = await _noteRepository.GetAsync(e =>
                e.Id == request.Id);

            if (note != null)
            {
                _logger.LogInformation($"Got a request get note Id: {note.Id}");
                var noteDto = _noteDxos.MapNoteDto(note);
                return noteDto;
            }

            return null;
        }
    }
}