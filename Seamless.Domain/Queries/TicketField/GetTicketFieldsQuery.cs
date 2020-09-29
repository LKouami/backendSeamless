using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.TicketField
{
    public class GetTicketFieldsQuery : QueryListBase<PagedResults<TicketFieldDto>>
    {
        public GetTicketFieldsQuery() : base()
        {

        }
        public GetTicketFieldsQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
