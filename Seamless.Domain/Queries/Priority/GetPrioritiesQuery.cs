using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Priority
{
    public class GetPrioritiesQuery : QueryListBase<PagedResults<PriorityDto>>
    {
        public GetPrioritiesQuery() : base()
        {

        }
        public GetPrioritiesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
