using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Faq;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Faq;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class CreateFaqHandler : IRequestHandler<CreateFaqCommand, FaqDto>
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IFaqDxos _faqDxos;
        private readonly IMediator _mediator;

        public CreateFaqHandler(IFaqRepository faqRepository,
            IMediator mediator,
            IFaqDxos faqDxos)
        {
            _faqRepository = faqRepository ?? throw new ArgumentNullException(nameof(faqRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _faqDxos = faqDxos ?? throw new ArgumentNullException(nameof(faqDxos));
        }


        public async Task<FaqDto> Handle(CreateFaqCommand request, CancellationToken cancellationToken)
        {
            var faqModel = _faqDxos.MapCreateRequesttoFaq(request);

            _faqRepository.Add(faqModel);

            if (await _faqRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new FaqCreatedEvent(faqModel.Id), cancellationToken);

            var faqDto = _faqDxos.MapFaqDto(faqModel);

            return faqDto;
        }
    }
}