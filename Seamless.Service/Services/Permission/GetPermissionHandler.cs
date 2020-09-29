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
    public class GetPermissionHandler : IRequestHandler<GetPermissionQuery, PermissionDto>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionDxos _permissionDxos;
        private readonly ILogger _logger;

        public GetPermissionHandler(IPermissionRepository permissionRepository, IPermissionDxos permissionDxos, ILogger<GetPermissionHandler> logger)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _permissionDxos = permissionDxos ?? throw new ArgumentNullException(nameof(permissionDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PermissionDto> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            var permission = await _permissionRepository.GetAsync(e =>
                e.Id == request.Id);

            if (permission != null)
            {
                _logger.LogInformation($"Got a request get permission Id: {permission.Id}");
                var permissionDto = _permissionDxos.MapPermissionDto(permission);
                return permissionDto;
            }

            return null;
        }
    }
}