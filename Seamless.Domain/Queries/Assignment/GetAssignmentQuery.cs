using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Assignment
{
    public class GetAssignmentQuery : GetOneQuery<long, AssignmentDto>
    {
        public GetAssignmentQuery(long Id) : base(Id)
        {

        }
    }
}
