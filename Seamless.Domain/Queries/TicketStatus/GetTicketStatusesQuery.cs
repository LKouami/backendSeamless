using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.TicketStatus
{
    public class GetTicketStatusesQuery : QueryListBase<PagedResults<TicketStatusDto>>
    {
        public GetTicketStatusesQuery() : base()
        {

        }
        public GetTicketStatusesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
