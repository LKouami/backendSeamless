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
    public class GetNotesHandler : IRequestHandler<GetNotesQuery, PagedResults<NoteDto>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger _logger;

        public GetNotesHandler(INoteRepository noteRepository, INoteDxos noteDxos,
            ILogger<GetNotesHandler> logger)
        {
            _noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _noteRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _noteRepository.GetListPageAsync(request,
               p =>
                   p.Note.ToLower().StartsWith(request.Search));
            }

        }
    }
}