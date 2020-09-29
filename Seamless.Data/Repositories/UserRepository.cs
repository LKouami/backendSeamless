using AutoMapper;
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
    public class UserRepository : Repository<AUser, UserDto, IUserDxos>, IUserRepository
    {
        public DbSet<AClaim> Claims;

        public UserRepository(SeamlessContext dbContext,
            ILogger<UserRepository> logger,
            IUserDxos dxos) : base(dbContext, logger, dxos)
        {
            Claims = _dbContext.Set<AClaim>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AUser, UserDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
            });

            _mapper = config.CreateMapper();
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Email.ToLower().Equals(email.ToLower()));

        }

        public async Task<IEnumerable<AClaim>> GetClaimsFromUser(int userId)
        {
            return await Claims.AsNoTracking().ToListAsync();
        }

        public async Task<AUser> Login(string email, string password)
        {
            AUser user = await
                ModelDbSets.AsNoTracking()
                .SingleOrDefaultAsync
                (
                    e => e.Email.ToLower().Equals(email.ToLower())
                );
            if (user == null)
            {
                return null;
            }
            else
            {
                //If user exists check password
                // TODO : Send this to a service
                if (user.Password == password)
                {
                    return user;
                }
                else
                {
                    return null;
                };
            }

        }
    }
}
