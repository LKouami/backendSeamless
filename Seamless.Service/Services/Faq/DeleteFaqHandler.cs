using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Faq;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Faq;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteFaqHandler : IRequestHandler<DeleteFaqCommand, DeleteResult>
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IMediator _mediator;

        public DeleteFaqHandler(IFaqRepository faqRepository,
            IMediator mediator)
        {
            _faqRepository = faqRepository ?? throw new ArgumentNullException(nameof(faqRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteFaqCommand request, CancellationToken cancellationToken)
        {
            var faqModel = await _faqRepository.GetAsync(e => e.Id == request.Id);

            _faqRepository.Remove(faqModel);

            if (await _faqRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new FaqDeletedEvent(faqModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}