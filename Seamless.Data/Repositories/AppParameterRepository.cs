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
    public class AppParameterRepository : Repository<SAppParameter, AppParameterDto, IAppParameterDxos>, IAppParameterRepository
    {
        public AppParameterRepository(SeamlessContext dbContext,
           ILogger<AppParameterRepository> logger,
           IAppParameterDxos appParameterDxos) : base(dbContext, logger, appParameterDxos)
        {
            //Code removed here
        }
        public async Task<bool> ParameterNameExistAsync(string parameterName)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.ParameterName.ToLower().Equals(parameterName.ToLower()));
        }
    }
}
