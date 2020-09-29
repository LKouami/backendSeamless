using Microsoft.Extensions.Logging;
using Seamless.Data.IRepositories;
using Seamless.Domain.Dxos;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Data.Repositories
{
    public class TicketFieldRepository : Repository<STicketField, TicketFieldDto, ITicketFieldDxos>, ITicketFieldRepository
    {
        public TicketFieldRepository(SeamlessContext dbContext,
           ILogger<TicketFieldRepository> logger,
           ITicketFieldDxos ticketFieldDxos) : base(dbContext, logger, ticketFieldDxos)
        {
            //Code removed here
        }
    }
}
