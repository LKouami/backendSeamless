using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Seamless.Domain.Queries.Category;
using Seamless.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Seamless.Service.Services
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryDxos _categoryDxos;
        private readonly ILogger _logger;

        public GetCategoryHandler(ICategoryRepository categoryRepository, ICategoryDxos categoryDxos, ILogger<GetCategoryHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _categoryDxos = categoryDxos ?? throw new ArgumentNullException(nameof(categoryDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(e =>
                e.Id == request.Id);

            if (category != null)
            {
                _logger.LogInformation($"Got a request get category Id: {category.Id}");
                var categoryDto = _categoryDxos.MapCategoryDto(category);
                return categoryDto;
            }

            return null;
        }
    }
}