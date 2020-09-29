using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.TicketField;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetTicketFieldsHandler : IRequestHandler<GetTicketFieldsQuery, PagedResults<TicketFieldDto>>
    {
        private readonly ITicketFieldRepository _ticketFieldRepository;
        private readonly ILogger _logger;

        public GetTicketFieldsHandler(ITicketFieldRepository ticketFieldRepository, ITicketFieldDxos ticketFieldDxos,
            ILogger<GetTicketFieldsHandler> logger)
        {
            _ticketFieldRepository = ticketFieldRepository ?? throw new ArgumentNullException(nameof(ticketFieldRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<TicketFieldDto>> Handle(GetTicketFieldsQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _ticketFieldRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _ticketFieldRepository.GetListPageAsync(request,
               p =>
                   p.Title.ToLower().StartsWith(request.Search));
            }

        }
    }
}