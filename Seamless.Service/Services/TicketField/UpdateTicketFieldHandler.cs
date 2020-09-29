using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.TicketField;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.TicketField;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateTicketFieldHandler : IRequestHandler<UpdateTicketFieldCommand, TicketFieldDto>
    {
        private readonly ITicketFieldRepository _ticketFieldRepository;
        private readonly ITicketFieldDxos _ticketFieldDxos;
        private readonly IMediator _mediator;

        public UpdateTicketFieldHandler(ITicketFieldRepository ticketFieldRepository,
            IMediator mediator,
            ITicketFieldDxos ticketFieldDxos)
        {
            _ticketFieldRepository = ticketFieldRepository ?? throw new ArgumentNullException(nameof(ticketFieldRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _ticketFieldDxos = ticketFieldDxos ?? throw new ArgumentNullException(nameof(ticketFieldDxos));
        }


        public async Task<TicketFieldDto> Handle(UpdateTicketFieldCommand request, CancellationToken cancellationToken)
        {
            var ticketFieldModel = _ticketFieldDxos.MapUpdateRequesttoTicketField(request);

            _ticketFieldRepository.Update(ticketFieldModel);

            if (await _ticketFieldRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new TicketFieldUpdatedEvent(ticketFieldModel.Id), cancellationToken);

            var ticketFieldDto = _ticketFieldDxos.MapTicketFieldDto(ticketFieldModel);

            return ticketFieldDto;
        }
    }
}