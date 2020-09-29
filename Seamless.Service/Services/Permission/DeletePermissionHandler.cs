using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Permission;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Permission;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeletePermissionHandler : IRequestHandler<DeletePermissionCommand, DeleteResult>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMediator _mediator;

        public DeletePermissionHandler(IPermissionRepository permissionRepository,
            IMediator mediator)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var permissionModel = await _permissionRepository.GetAsync(e => e.Id == request.Id);

            _permissionRepository.Remove(permissionModel);

            if (await _permissionRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new PermissionDeletedEvent(permissionModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}