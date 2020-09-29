using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seamless.Data.IRepositories
{
    public interface IAssignmentRepository : IRepository<SAssignment, AssignmentDto>
    {
        Task<bool> AssigneeIdExistAsync(long? assigneeId);
    }
}
