using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Priority;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Priority;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class CreatePriorityHandler : IRequestHandler<CreatePriorityCommand, PriorityDto>
    {
        private readonly IPriorityRepository _priorityRepository;
        private readonly IPriorityDxos _priorityDxos;
        private readonly IMediator _mediator;

        public CreatePriorityHandler(IPriorityRepository priorityRepository,
            IMediator mediator,
            IPriorityDxos priorityDxos)
        {
            _priorityRepository = priorityRepository ?? throw new ArgumentNullException(nameof(priorityRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _priorityDxos = priorityDxos ?? throw new ArgumentNullException(nameof(priorityDxos));
        }


        public async Task<PriorityDto> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priorityModel = _priorityDxos.MapCreateRequesttoPriority(request);

            _priorityRepository.Add(priorityModel);

            if (await _priorityRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new PriorityCreatedEvent(priorityModel.Id), cancellationToken);

            var priorityDto = _priorityDxos.MapPriorityDto(priorityModel);

            return priorityDto;
        }
    }
}