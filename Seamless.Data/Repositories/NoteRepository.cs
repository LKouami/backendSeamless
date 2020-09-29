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
    public class NoteRepository : Repository<SNote, NoteDto, INoteDxos>, INoteRepository
    {
        public NoteRepository(SeamlessContext dbContext,
           ILogger<NoteRepository> logger,
           INoteDxos noteDxos) : base(dbContext, logger, noteDxos)
        {
            //Code removed here
        }
    }
}
