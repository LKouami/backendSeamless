using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seamless.Data.IRepositories
{
    public interface IActivityLogRepository : IRepository<SActivityLog, ActivityLogDto>
    {
        Task<bool> ActionExistAsync(string action);
    }
}
