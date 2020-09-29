using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seamless.Data.IRepositories
{
    public interface IUserRepository : IRepository<AUser, UserDto>
    {
        Task<AUser> Login(string email, string password);
        Task<bool> EmailExistAsync(string email);

        Task<IEnumerable<AClaim>> GetClaimsFromUser(int userId);
    }
}
