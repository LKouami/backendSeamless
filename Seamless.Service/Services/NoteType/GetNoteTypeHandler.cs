using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.NoteType;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetNoteTypeHandler : IRequestHandler<GetNoteTypeQuery, NoteTypeDto>
    {
        private readonly INoteTypeRepository _noteTypeRepository;
        private readonly INoteTypeDxos _noteTypeDxos;
        private readonly ILogger _logger;

        public GetNoteTypeHandler(INoteTypeRepository noteTypeRepository, INoteTypeDxos noteTypeDxos, ILogger<GetNoteTypeHandler> logger)
        {
            _noteTypeRepository = noteTypeRepository ?? throw new ArgumentNullException(nameof(noteTypeRepository));
            _noteTypeDxos = noteTypeDxos ?? throw new ArgumentNullException(nameof(noteTypeDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<NoteTypeDto> Handle(GetNoteTypeQuery request, CancellationToken cancellationToken)
        {
            var noteType = await _noteTypeRepository.GetAsync(e =>
                e.Id == request.Id);

            if (noteType != null)
            {
                _logger.LogInformation($"Got a request get noteType Id: {noteType.Id}");
                var noteTypeDto = _noteTypeDxos.MapNoteTypeDto(noteType);
                return noteTypeDto;
            }

            return null;
        }
    }
}