using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Message;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetMessageHandler : IRequestHandler<GetMessageQuery, MessageDto>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMessageDxos _messageDxos;
        private readonly ILogger _logger;

        public GetMessageHandler(IMessageRepository messageRepository, IMessageDxos messageDxos, ILogger<GetMessageHandler> logger)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _messageDxos = messageDxos ?? throw new ArgumentNullException(nameof(messageDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<MessageDto> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetAsync(e =>
                e.Id == request.Id);

            if (message != null)
            {
                _logger.LogInformation($"Got a request get message Id: {message.Id}");
                var messageDto = _messageDxos.MapMessageDto(message);
                return messageDto;
            }

            return null;
        }
    }
}