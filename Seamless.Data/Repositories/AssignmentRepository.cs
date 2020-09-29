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
    public class AssignmentRepository : Repository<SAssignment, AssignmentDto, IAssignmentDxos>, IAssignmentRepository
    {
        public AssignmentRepository(SeamlessContext dbContext,
           ILogger<AssignmentRepository> logger,
           IAssignmentDxos assignmentDxos) : base(dbContext, logger, assignmentDxos)
        {
            //Code removed here
        }
        public async Task<bool> AssigneeIdExistAsync(long? assigneeId)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.AssigneeId.Equals(assigneeId));
        }
    }
}
