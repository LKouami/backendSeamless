using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Category;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Category;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, DeleteResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediator _mediator;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository,
            IMediator mediator)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryModel = await _categoryRepository.GetAsync(e => e.Id == request.Id);

            _categoryRepository.Remove(categoryModel);

            if (await _categoryRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new CategoryDeletedEvent(categoryModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}