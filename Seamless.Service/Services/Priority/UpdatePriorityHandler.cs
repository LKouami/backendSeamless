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
    public class UpdatePriorityHandler : IRequestHandler<UpdatePriorityCommand, PriorityDto>
    {
        private readonly IPriorityRepository _priorityRepository;
        private readonly IPriorityDxos _priorityDxos;
        private readonly IMediator _mediator;

        public UpdatePriorityHandler(IPriorityRepository priorityRepository,
            IMediator mediator,
            IPriorityDxos priorityDxos)
        {
            _priorityRepository = priorityRepository ?? throw new ArgumentNullException(nameof(priorityRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _priorityDxos = priorityDxos ?? throw new ArgumentNullException(nameof(priorityDxos));
        }


        public async Task<PriorityDto> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priorityModel = _priorityDxos.MapUpdateRequesttoPriority(request);

            _priorityRepository.Update(priorityModel);

            if (await _priorityRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new PriorityUpdatedEvent(priorityModel.Id), cancellationToken);

            var priorityDto = _priorityDxos.MapPriorityDto(priorityModel);

            return priorityDto;
        }
    }
}