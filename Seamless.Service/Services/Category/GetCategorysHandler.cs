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
    public class GetCategorysHandler : IRequestHandler<GetCategoriesQuery, PagedResults<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger _logger;

        public GetCategorysHandler(ICategoryRepository categoryRepository, ICategoryDxos categoryDxos,
            ILogger<GetCategorysHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _categoryRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _categoryRepository.GetListPageAsync(request,
               p =>
                   p.Name.ToLower().StartsWith(request.Search));
            }

        }
    }
}