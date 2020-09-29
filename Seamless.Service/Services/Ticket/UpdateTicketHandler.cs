using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Ticket;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Ticket;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, TicketDto>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketDxos _ticketDxos;
        private readonly IMediator _mediator;

        public UpdateTicketHandler(ITicketRepository ticketRepository,
            IMediator mediator,
            ITicketDxos ticketDxos)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _ticketDxos = ticketDxos ?? throw new ArgumentNullException(nameof(ticketDxos));
        }


        public async Task<TicketDto> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticketModel = _ticketDxos.MapUpdateRequesttoTicket(request);

            _ticketRepository.Update(ticketModel);

            if (await _ticketRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new TicketUpdatedEvent(ticketModel.Id), cancellationToken);

            var ticketDto = _ticketDxos.MapTicketDto(ticketModel);

            return ticketDto;
        }
    }
}