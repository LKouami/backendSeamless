using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Message
{
    public class GetMessageQuery : GetOneQuery<long, MessageDto>
    {
        public GetMessageQuery(long Id) : base(Id)
        {

        }
    }
}
