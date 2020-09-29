using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Ticket;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetTicketsHandler : IRequestHandler<GetTicketsQuery, PagedResults<TicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ILogger _logger;

        public GetTicketsHandler(ITicketRepository ticketRepository, ITicketDxos ticketDxos,
            ILogger<GetTicketsHandler> logger)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _ticketRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _ticketRepository.GetListPageAsync(request,
               p =>
                   p.Description.ToLower().StartsWith(request.Search));
            }

        }
    }
}