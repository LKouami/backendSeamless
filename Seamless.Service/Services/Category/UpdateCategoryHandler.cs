using Seamless.Data.IRepositories;
using Seamless.Domain.Commands.Category;
using Seamless.Model.Dtos;
using Seamless.Domain.Events.Category;
using Seamless.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryDxos _categoryDxos;
        private readonly IMediator _mediator;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository,
            IMediator mediator,
            ICategoryDxos categoryDxos)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _categoryDxos = categoryDxos ?? throw new ArgumentNullException(nameof(categoryDxos));
        }


        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryModel = _categoryDxos.MapUpdateRequesttoCategory(request);

            _categoryRepository.Update(categoryModel);

            if (await _categoryRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new CategoryUpdatedEvent(categoryModel.Id), cancellationToken);

            var categoryDto = _categoryDxos.MapCategoryDto(categoryModel);

            return categoryDto;
        }
    }
}