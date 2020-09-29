using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.ActivityLog
{
    public class GetActivityLogQuery : GetOneQuery<long, ActivityLogDto>
    {
        public GetActivityLogQuery(long Id) : base(Id)
        {

        }
    }
}
