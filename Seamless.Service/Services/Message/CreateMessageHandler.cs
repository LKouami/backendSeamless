﻿using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Message;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Message;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, MessageDto>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageDxos _messageDxos;
        private readonly IMediator _mediator;

        public CreateMessageHandler(IMessageRepository messageRepository,
            IMediator mediator,
            IMessageDxos messageDxos)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _messageDxos = messageDxos ?? throw new ArgumentNullException(nameof(messageDxos));
        }


        public async Task<MessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var messageModel = _messageDxos.MapCreateRequesttoMessage(request);

            _messageRepository.Add(messageModel);

            if (await _messageRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new MessageCreatedEvent(messageModel.Id), cancellationToken);

            var messageDto = _messageDxos.MapMessageDto(messageModel);

            return messageDto;
        }
    }
}