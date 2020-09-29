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
    public class GetNoteTypesHandler : IRequestHandler<GetNoteTypesQuery, PagedResults<NoteTypeDto>>
    {
        private readonly INoteTypeRepository _noteTypeRepository;
        private readonly ILogger _logger;

        public GetNoteTypesHandler(INoteTypeRepository noteTypeRepository, INoteTypeDxos noteTypeDxos,
            ILogger<GetNoteTypesHandler> logger)
        {
            _noteTypeRepository = noteTypeRepository ?? throw new ArgumentNullException(nameof(noteTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<NoteTypeDto>> Handle(GetNoteTypesQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _noteTypeRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _noteTypeRepository.GetListPageAsync(request,
               p =>
                   p.Name.ToLower().StartsWith(request.Search));
            }

        }
    }
}