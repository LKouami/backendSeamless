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
    public class GetTicketStatusHandler : IRequestHandler<GetTicketStatusQuery, TicketStatusDto>
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly ITicketStatusDxos _ticketStatusDxos;
        private readonly ILogger _logger;

        public GetTicketStatusHandler(ITicketStatusRepository ticketStatusRepository, ITicketStatusDxos ticketStatusDxos, ILogger<GetTicketStatusHandler> logger)
        {
            _ticketStatusRepository = ticketStatusRepository ?? throw new ArgumentNullException(nameof(ticketStatusRepository));
            _ticketStatusDxos = ticketStatusDxos ?? throw new ArgumentNullException(nameof(ticketStatusDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TicketStatusDto> Handle(GetTicketStatusQuery request, CancellationToken cancellationToken)
        {
            var ticketStatus = await _ticketStatusRepository.GetAsync(e =>
                e.Id == request.Id);

            if (ticketStatus != null)
            {
                _logger.LogInformation($"Got a request get ticketStatus Id: {ticketStatus.Id}");
                var ticketStatusDto = _ticketStatusDxos.MapTicketStatusDto(ticketStatus);
                return ticketStatusDto;
            }

            return null;
        }
    }
}