using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seamless.Data.IRepositories
{
    public interface IFaqRepository : IRepository<SFaq, FaqDto>
    {
        Task<bool> TitleExistAsync(string title);
    }
}
