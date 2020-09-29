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
    public class GetTicketHandler : IRequestHandler<GetTicketQuery, TicketDto>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketDxos _ticketDxos;
        private readonly ILogger _logger;

        public GetTicketHandler(ITicketRepository ticketRepository, ITicketDxos ticketDxos, ILogger<GetTicketHandler> logger)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _ticketDxos = ticketDxos ?? throw new ArgumentNullException(nameof(ticketDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TicketDto> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetAsync(e =>
                e.Id == request.Id);

            if (ticket != null)
            {
                _logger.LogInformation($"Got a request get ticket Id: {ticket.Id}");
                var ticketDto = _ticketDxos.MapTicketDto(ticket);
                return ticketDto;
            }

            return null;
        }
    }
}