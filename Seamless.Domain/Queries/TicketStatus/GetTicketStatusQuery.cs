using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.TicketStatus
{
    public class GetTicketStatusQuery : GetOneQuery<long, TicketStatusDto>
    {
        public GetTicketStatusQuery(long Id) : base(Id)
        {

        }
    }
}
