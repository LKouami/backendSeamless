using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Ticket
{
    public class GetTicketQuery : GetOneQuery<long, TicketDto>
    {
        public GetTicketQuery(long Id) : base(Id)
        {

        }
    }
}
