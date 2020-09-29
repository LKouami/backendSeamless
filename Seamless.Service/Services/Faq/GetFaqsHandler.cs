using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Faq;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetFaqsHandler : IRequestHandler<GetFaqsQuery, PagedResults<FaqDto>>
    {
        private readonly IFaqRepository _faqRepository;
        private readonly ILogger _logger;

        public GetFaqsHandler(IFaqRepository faqRepository, IFaqDxos faqDxos,
            ILogger<GetFaqsHandler> logger)
        {
            _faqRepository = faqRepository ?? throw new ArgumentNullException(nameof(faqRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<FaqDto>> Handle(GetFaqsQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _faqRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _faqRepository.GetListPageAsync(request,
               p =>
                   p.Title.ToLower().StartsWith(request.Search));
            }

        }
    }
}