using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.AppParameter;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.AppParameter;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateAppParameterHandler : IRequestHandler<UpdateAppParameterCommand, AppParameterDto>
    {
        private readonly IAppParameterRepository _appParameterRepository;
        private readonly IAppParameterDxos _appParameterDxos;
        private readonly IMediator _mediator;

        public UpdateAppParameterHandler(IAppParameterRepository appParameterRepository,
            IMediator mediator,
            IAppParameterDxos appParameterDxos)
        {
            _appParameterRepository = appParameterRepository ?? throw new ArgumentNullException(nameof(appParameterRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _appParameterDxos = appParameterDxos ?? throw new ArgumentNullException(nameof(appParameterDxos));
        }


        public async Task<AppParameterDto> Handle(UpdateAppParameterCommand request, CancellationToken cancellationToken)
        {
            var appParameterModel = _appParameterDxos.MapUpdateRequesttoAppParameter(request);

            _appParameterRepository.Update(appParameterModel);

            if (await _appParameterRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new AppParameterUpdatedEvent(appParameterModel.Id), cancellationToken);

            var appParameterDto = _appParameterDxos.MapAppParameterDto(appParameterModel);

            return appParameterDto;
        }
    }
}