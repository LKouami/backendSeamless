using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Permission;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetPermissionsHandler : IRequestHandler<GetPermissionsQuery, PagedResults<PermissionDto>>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly ILogger _logger;

        public GetPermissionsHandler(IPermissionRepository permissionRepository, IPermissionDxos permissionDxos,
            ILogger<GetPermissionsHandler> logger)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _permissionRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _permissionRepository.GetListPageAsync(request,
               p =>
                   p.Name.ToLower().StartsWith(request.Search));
            }

        }
    }
}