using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Permission;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Permission;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermissionCommand, PermissionDto>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionDxos _permissionDxos;
        private readonly IMediator _mediator;

        public CreatePermissionHandler(IPermissionRepository permissionRepository,
            IMediator mediator,
            IPermissionDxos permissionDxos)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _permissionDxos = permissionDxos ?? throw new ArgumentNullException(nameof(permissionDxos));
        }


        public async Task<PermissionDto> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permissionModel = _permissionDxos.MapCreateRequesttoPermission(request);

            _permissionRepository.Add(permissionModel);

            if (await _permissionRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new PermissionCreatedEvent(permissionModel.Id), cancellationToken);

            var permissionDto = _permissionDxos.MapPermissionDto(permissionModel);

            return permissionDto;
        }
    }
}