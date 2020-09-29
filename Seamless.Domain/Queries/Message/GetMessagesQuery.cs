using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Message
{
    public class GetMessagesQuery : QueryListBase<PagedResults<MessageDto>>
    {
        public GetMessagesQuery() : base()
        {

        }
        public GetMessagesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
