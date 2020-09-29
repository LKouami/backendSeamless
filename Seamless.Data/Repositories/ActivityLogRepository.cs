using AutoMapper;
using Seamless.Data.IRepositories;
using Seamless.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Seamless.Model.Models;
using Seamless.Domain.Dxos;

namespace Seamless.Data.Repositories
{
    public class ActivityLogRepository : Repository<SActivityLog, ActivityLogDto, IActivityLogDxos>, IActivityLogRepository
    {
        public ActivityLogRepository(SeamlessContext dbContext,
           ILogger<ActivityLogRepository> logger,
           IActivityLogDxos activityLogDxos) : base(dbContext, logger, activityLogDxos)
        {
            //Code removed here
        }

        public async Task<bool> ActionExistAsync(string action)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Action.ToLower().Equals(action.ToLower()));
        }
    }
}
