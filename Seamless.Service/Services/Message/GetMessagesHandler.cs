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
    public class GetMessagesHandler : IRequestHandler<GetMessagesQuery, PagedResults<MessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ILogger _logger;

        public GetMessagesHandler(IMessageRepository messageRepository, IMessageDxos messageDxos,
            ILogger<GetMessagesHandler> logger)
        {
            _messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<MessageDto>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _messageRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _messageRepository.GetListPageAsync(request,
               p =>
                   p.Text.ToLower().StartsWith(request.Search));
            }

        }
    }
}