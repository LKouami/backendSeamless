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
    public class GetAppParametersHandler : IRequestHandler<GetAppParametersQuery, PagedResults<AppParameterDto>>
    {
        private readonly IAppParameterRepository _appParameterRepository;
        private readonly ILogger _logger;

        public GetAppParametersHandler(IAppParameterRepository appParameterRepository, IAppParameterDxos appParameterDxos,
            ILogger<GetAppParametersHandler> logger)
        {
            _appParameterRepository = appParameterRepository ?? throw new ArgumentNullException(nameof(appParameterRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<AppParameterDto>> Handle(GetAppParametersQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _appParameterRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _appParameterRepository.GetListPageAsync(request,
               p =>
                   p.ParameterName.ToLower().StartsWith(request.Search));
            }

        }
    }
}