using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.TicketStatus;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.TicketStatus;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class CreateTicketStatusHandler : IRequestHandler<CreateTicketStatusCommand, TicketStatusDto>
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly ITicketStatusDxos _ticketStatusDxos;
        private readonly IMediator _mediator;

        public CreateTicketStatusHandler(ITicketStatusRepository ticketStatusRepository,
            IMediator mediator,
            ITicketStatusDxos ticketStatusDxos)
        {
            _ticketStatusRepository = ticketStatusRepository ?? throw new ArgumentNullException(nameof(ticketStatusRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _ticketStatusDxos = ticketStatusDxos ?? throw new ArgumentNullException(nameof(ticketStatusDxos));
        }


        public async Task<TicketStatusDto> Handle(CreateTicketStatusCommand request, CancellationToken cancellationToken)
        {
            var ticketStatusModel = _ticketStatusDxos.MapCreateRequesttoTicketStatus(request);

            _ticketStatusRepository.Add(ticketStatusModel);

            if (await _ticketStatusRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new TicketStatusCreatedEvent(ticketStatusModel.Id), cancellationToken);

            var ticketStatusDto = _ticketStatusDxos.MapTicketStatusDto(ticketStatusModel);

            return ticketStatusDto;
        }
    }
}