using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.AppParameter;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetAppParameterHandler : IRequestHandler<GetAppParameterQuery, AppParameterDto>
    {
        private readonly IAppParameterRepository _appParameterRepository;
        private readonly IAppParameterDxos _appParameterDxos;
        private readonly ILogger _logger;

        public GetAppParameterHandler(IAppParameterRepository appParameterRepository, IAppParameterDxos appParameterDxos, ILogger<GetAppParameterHandler> logger)
        {
            _appParameterRepository = appParameterRepository ?? throw new ArgumentNullException(nameof(appParameterRepository));
            _appParameterDxos = appParameterDxos ?? throw new ArgumentNullException(nameof(appParameterDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AppParameterDto> Handle(GetAppParameterQuery request, CancellationToken cancellationToken)
        {
            var appParameter = await _appParameterRepository.GetAsync(e =>
                e.Id == request.Id);

            if (appParameter != null)
            {
                _logger.LogInformation($"Got a request get appParameter Id: {appParameter.Id}");
                var appParameterDto = _appParameterDxos.MapAppParameterDto(appParameter);
                return appParameterDto;
            }

            return null;
        }
    }
}