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
    public class FaqRepository : Repository<SFaq, FaqDto, IFaqDxos>, IFaqRepository
    {
        public FaqRepository(SeamlessContext dbContext,
           ILogger<FaqRepository> logger,
           IFaqDxos faqDxos) : base(dbContext, logger, faqDxos)
        {
            //Code removed here
        }
        public async Task<bool> TitleExistAsync(string title)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Title.ToLower().Equals(title.ToLower()));
        }
    }
}
