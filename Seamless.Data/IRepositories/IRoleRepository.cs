using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Seamless.Model.Dtos;
using Seamless.Model.Models;

namespace Seamless.Data.IRepositories
{
    public interface IRoleRepository : IRepository<ARole, RoleDto>
    {
        Task<IEnumerable<ARole>> GetRolesFromUser(int userId);
        Task<IEnumerable<AClaim>> GetRolesClaimsFromUser(int userId);
    }
}