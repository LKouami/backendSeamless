using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Priority
{
    public class GetPriorityQuery : GetOneQuery<long, PriorityDto>
    {
        public GetPriorityQuery(long Id) : base(Id)
        {

        }
    }
}
