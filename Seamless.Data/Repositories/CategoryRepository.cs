using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Seamless.Data.IRepositories;
using Seamless.Domain.Dxos;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seamless.Data.Repositories
{
    public class CategoryRepository : Repository<SCategory, CategoryDto, ICategoryDxos>, ICategoryRepository
    {
        public CategoryRepository(SeamlessContext dbContext,
           ILogger<CategoryRepository> logger,
           ICategoryDxos categoryDxos) : base(dbContext, logger, categoryDxos)
        {
            //Code removed here
        }
        public async Task<bool> NameExistAsync(string name)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
