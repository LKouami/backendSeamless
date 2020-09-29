using Seamless.Domain.Commands.Category;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using Seamless.Domain.Dxos.Common;

namespace Seamless.Domain.Dxos
{
    public interface ICategoryDxos : IBaseDxos
    {
        CategoryDto MapCategoryDto(SCategory category);
        SCategory MapCreateRequesttoCategory(CreateCategoryCommand category);
        SCategory MapUpdateRequesttoCategory(UpdateCategoryCommand category);
    }
}
