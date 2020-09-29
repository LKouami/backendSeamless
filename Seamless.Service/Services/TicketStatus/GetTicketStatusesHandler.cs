using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.TicketStatus;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetTicketStatusesHandler : IRequestHandler<GetTicketStatusesQuery, PagedResults<TicketStatusDto>>
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly ILogger _logger;

        public GetTicketStatusesHandler(ITicketStatusRepository ticketStatusRepository, ITicketStatusDxos ticketStatusDxos,
            ILogger<GetTicketStatusesHandler> logger)
        {
            _ticketStatusRepository = ticketStatusRepository ?? throw new ArgumentNullException(nameof(ticketStatusRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<TicketStatusDto>> Handle(GetTicketStatusesQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _ticketStatusRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _ticketStatusRepository.GetListPageAsync(request,
               p =>
                   p.Name.ToLower().StartsWith(request.Search));
            }

        }
    }
}