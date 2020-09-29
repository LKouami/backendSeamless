using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Faq
{
    public class GetFaqQuery : GetOneQuery<long, FaqDto>
    {
        public GetFaqQuery(long Id) : base(Id)
        {

        }
    }
}
