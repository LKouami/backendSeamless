using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seamless.Data.IRepositories
{
    public interface IAppParameterRepository : IRepository<SAppParameter, AppParameterDto>
    {
        Task<bool> ParameterNameExistAsync(string parameterName);
    }
}
