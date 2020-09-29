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
    public class CreateAppParameterHandler : IRequestHandler<CreateAppParameterCommand, AppParameterDto>
    {
        private readonly IAppParameterRepository _appParameterRepository;
        private readonly IAppParameterDxos _appParameterDxos;
        private readonly IMediator _mediator;

        public CreateAppParameterHandler(IAppParameterRepository appParameterRepository,
            IMediator mediator,
            IAppParameterDxos appParameterDxos)
        {
            _appParameterRepository = appParameterRepository ?? throw new ArgumentNullException(nameof(appParameterRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _appParameterDxos = appParameterDxos ?? throw new ArgumentNullException(nameof(appParameterDxos));
        }


        public async Task<AppParameterDto> Handle(CreateAppParameterCommand request, CancellationToken cancellationToken)
        {
            var appParameterModel = _appParameterDxos.MapCreateRequesttoAppParameter(request);

            _appParameterRepository.Add(appParameterModel);

            if (await _appParameterRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new AppParameterCreatedEvent(appParameterModel.Id), cancellationToken);

            var appParameterDto = _appParameterDxos.MapAppParameterDto(appParameterModel);

            return appParameterDto;
        }
    }
}