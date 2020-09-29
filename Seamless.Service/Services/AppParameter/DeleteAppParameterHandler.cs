using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.AppParameter;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.AppParameter;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteAppParameterHandler : IRequestHandler<DeleteAppParameterCommand, DeleteResult>
    {
        private readonly IAppParameterRepository _appParameterRepository;
        private readonly IMediator _mediator;

        public DeleteAppParameterHandler(IAppParameterRepository appParameterRepository,
            IMediator mediator)
        {
            _appParameterRepository = appParameterRepository ?? throw new ArgumentNullException(nameof(appParameterRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteAppParameterCommand request, CancellationToken cancellationToken)
        {
            var appParameterModel = await _appParameterRepository.GetAsync(e => e.Id == request.Id);

            _appParameterRepository.Remove(appParameterModel);

            if (await _appParameterRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new AppParameterDeletedEvent(appParameterModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}