using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Ticket
{
    public class GetTicketsQuery : QueryListBase<PagedResults<TicketDto>>
    {
        public GetTicketsQuery() : base()
        {

        }
        public GetTicketsQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
