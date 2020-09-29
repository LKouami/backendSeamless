using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Message;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Message;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteMessageHandler : IRequestHandler<DeleteMessageCommand, DeleteResult>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMediator _mediator;

        public DeleteMessageHandler(IMessageRepository messageRepository,
            IMediator mediator)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var messageModel = await _messageRepository.GetAsync(e => e.Id == request.Id);

            _messageRepository.Remove(messageModel);

            if (await _messageRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new MessageDeletedEvent(messageModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}