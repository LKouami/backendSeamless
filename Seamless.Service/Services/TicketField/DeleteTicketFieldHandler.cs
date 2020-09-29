using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.TicketField;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.TicketField;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteTicketFieldHandler : IRequestHandler<DeleteTicketFieldCommand, DeleteResult>
    {
        private readonly ITicketFieldRepository _ticketFieldRepository;
        private readonly IMediator _mediator;

        public DeleteTicketFieldHandler(ITicketFieldRepository ticketFieldRepository,
            IMediator mediator)
        {
            _ticketFieldRepository = ticketFieldRepository ?? throw new ArgumentNullException(nameof(ticketFieldRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteTicketFieldCommand request, CancellationToken cancellationToken)
        {
            var ticketFieldModel = await _ticketFieldRepository.GetAsync(e => e.Id == request.Id);

            _ticketFieldRepository.Remove(ticketFieldModel);

            if (await _ticketFieldRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new TicketFieldDeletedEvent(ticketFieldModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}