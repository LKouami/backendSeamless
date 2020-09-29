using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seamless.Data.IRepositories
{
    public interface IPriorityRepository : IRepository<SPriority, PriorityDto>
    {
        Task<bool> NameExistAsync(string name);
    }
}
