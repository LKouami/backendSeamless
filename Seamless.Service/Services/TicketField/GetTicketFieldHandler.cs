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
    public class GetTicketFieldHandler : IRequestHandler<GetTicketFieldQuery, TicketFieldDto>
    {
        private readonly ITicketFieldRepository _ticketFieldRepository;
        private readonly ITicketFieldDxos _ticketFieldDxos;
        private readonly ILogger _logger;

        public GetTicketFieldHandler(ITicketFieldRepository ticketFieldRepository, ITicketFieldDxos ticketFieldDxos, ILogger<GetTicketFieldHandler> logger)
        {
            _ticketFieldRepository = ticketFieldRepository ?? throw new ArgumentNullException(nameof(ticketFieldRepository));
            _ticketFieldDxos = ticketFieldDxos ?? throw new ArgumentNullException(nameof(ticketFieldDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TicketFieldDto> Handle(GetTicketFieldQuery request, CancellationToken cancellationToken)
        {
            var ticketField = await _ticketFieldRepository.GetAsync(e =>
                e.Id == request.Id);

            if (ticketField != null)
            {
                _logger.LogInformation($"Got a request get ticketField Id: {ticketField.Id}");
                var ticketFieldDto = _ticketFieldDxos.MapTicketFieldDto(ticketField);
                return ticketFieldDto;
            }

            return null;
        }
    }
}