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
    public class MessageRepository : Repository<SMessage, MessageDto, IMessageDxos>, IMessageRepository
    {
        public MessageRepository(SeamlessContext dbContext,
           ILogger<MessageRepository> logger,
           IMessageDxos messageDxos) : base(dbContext, logger, messageDxos)
        {
            //Code removed here
        }
    }
}
