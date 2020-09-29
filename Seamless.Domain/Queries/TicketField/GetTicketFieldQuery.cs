using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.TicketField
{
    public class GetTicketFieldQuery : GetOneQuery<long, TicketFieldDto>
    {
        public GetTicketFieldQuery(long Id) : base(Id)
        {

        }
    }
}
