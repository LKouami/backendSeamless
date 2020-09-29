using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Faq
{
    public class GetFaqsQuery : QueryListBase<PagedResults<FaqDto>>
    {
        public GetFaqsQuery() : base()
        {

        }
        public GetFaqsQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
