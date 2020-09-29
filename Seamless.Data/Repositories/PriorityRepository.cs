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
    public class PriorityRepository : Repository<SPriority, PriorityDto, IPriorityDxos>, IPriorityRepository
    {
        public PriorityRepository(SeamlessContext dbContext,
           ILogger<PriorityRepository> logger,
           IPriorityDxos priorityDxos) : base(dbContext, logger, priorityDxos)
        {
            //Code removed here
        }
        public async Task<bool> NameExistAsync(string name)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Name.ToLower().Equals(name.ToLower()));
        }
    }
}
