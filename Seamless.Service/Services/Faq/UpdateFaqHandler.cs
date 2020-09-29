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
    public class UpdateFaqHandler : IRequestHandler<UpdateFaqCommand, FaqDto>
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IFaqDxos _faqDxos;
        private readonly IMediator _mediator;

        public UpdateFaqHandler(IFaqRepository faqRepository,
            IMediator mediator,
            IFaqDxos faqDxos)
        {
            _faqRepository = faqRepository ?? throw new ArgumentNullException(nameof(faqRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _faqDxos = faqDxos ?? throw new ArgumentNullException(nameof(faqDxos));
        }


        public async Task<FaqDto> Handle(UpdateFaqCommand request, CancellationToken cancellationToken)
        {
            var faqModel = _faqDxos.MapUpdateRequesttoFaq(request);

            _faqRepository.Update(faqModel);

            if (await _faqRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new FaqUpdatedEvent(faqModel.Id), cancellationToken);

            var faqDto = _faqDxos.MapFaqDto(faqModel);

            return faqDto;
        }
    }
}