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
    public class TicketRepository : Repository<STicket, TicketDto, ITicketDxos>, ITicketRepository
    {
        public TicketRepository(SeamlessContext dbContext,
           ILogger<TicketRepository> logger,
           ITicketDxos ticketDxos) : base(dbContext, logger, ticketDxos)
        {
            //Code removed here
        }
    }
}
