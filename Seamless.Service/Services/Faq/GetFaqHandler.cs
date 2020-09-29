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
    public class GetFaqHandler : IRequestHandler<GetFaqQuery, FaqDto>
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IFaqDxos _faqDxos;
        private readonly ILogger _logger;

        public GetFaqHandler(IFaqRepository faqRepository, IFaqDxos faqDxos, ILogger<GetFaqHandler> logger)
        {
            _faqRepository = faqRepository ?? throw new ArgumentNullException(nameof(faqRepository));
            _faqDxos = faqDxos ?? throw new ArgumentNullException(nameof(faqDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<FaqDto> Handle(GetFaqQuery request, CancellationToken cancellationToken)
        {
            var faq = await _faqRepository.GetAsync(e =>
                e.Id == request.Id);

            if (faq != null)
            {
                _logger.LogInformation($"Got a request get faq Id: {faq.Id}");
                var faqDto = _faqDxos.MapFaqDto(faq);
                return faqDto;
            }

            return null;
        }
    }
}