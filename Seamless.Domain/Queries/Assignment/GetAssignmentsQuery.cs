using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Assignment
{
    public class GetAssignmentsQuery : QueryListBase<PagedResults<AssignmentDto>>
    {
        public GetAssignmentsQuery() : base()
        {

        }
        public GetAssignmentsQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
