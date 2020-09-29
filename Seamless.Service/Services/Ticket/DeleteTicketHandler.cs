using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Ticket;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Ticket;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, DeleteResult>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMediator _mediator;

        public DeleteTicketHandler(ITicketRepository ticketRepository,
            IMediator mediator)
        {
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticketModel = await _ticketRepository.GetAsync(e => e.Id == request.Id);

            _ticketRepository.Remove(ticketModel);

            if (await _ticketRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new TicketDeletedEvent(ticketModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}