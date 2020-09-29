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
    public class CreateTicketFieldHandler : IRequestHandler<CreateTicketFieldCommand, TicketFieldDto>
    {
        private readonly ITicketFieldRepository _ticketFieldRepository;
        private readonly ITicketFieldDxos _ticketFieldDxos;
        private readonly IMediator _mediator;

        public CreateTicketFieldHandler(ITicketFieldRepository ticketFieldRepository,
            IMediator mediator,
            ITicketFieldDxos ticketFieldDxos)
        {
            _ticketFieldRepository = ticketFieldRepository ?? throw new ArgumentNullException(nameof(ticketFieldRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _ticketFieldDxos = ticketFieldDxos ?? throw new ArgumentNullException(nameof(ticketFieldDxos));
        }


        public async Task<TicketFieldDto> Handle(CreateTicketFieldCommand request, CancellationToken cancellationToken)
        {
            var ticketFieldModel = _ticketFieldDxos.MapCreateRequesttoTicketField(request);

            _ticketFieldRepository.Add(ticketFieldModel);

            if (await _ticketFieldRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new TicketFieldCreatedEvent(ticketFieldModel.Id), cancellationToken);

            var ticketFieldDto = _ticketFieldDxos.MapTicketFieldDto(ticketFieldModel);

            return ticketFieldDto;
        }
    }
}