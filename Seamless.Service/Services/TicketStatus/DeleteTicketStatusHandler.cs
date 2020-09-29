using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.TicketStatus;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.TicketStatus;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteTicketStatusHandler : IRequestHandler<DeleteTicketStatusCommand, DeleteResult>
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly IMediator _mediator;

        public DeleteTicketStatusHandler(ITicketStatusRepository ticketStatusRepository,
            IMediator mediator)
        {
            _ticketStatusRepository = ticketStatusRepository ?? throw new ArgumentNullException(nameof(ticketStatusRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteTicketStatusCommand request, CancellationToken cancellationToken)
        {
            var ticketStatusModel = await _ticketStatusRepository.GetAsync(e => e.Id == request.Id);

            _ticketStatusRepository.Remove(ticketStatusModel);

            if (await _ticketStatusRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new TicketStatusDeletedEvent(ticketStatusModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}