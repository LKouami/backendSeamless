using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.User
{
    public class GetUsersQuery : QueryListBase<PagedResults<UserDto>>
    {
        public GetUsersQuery() : base()
        {

        }
        public GetUsersQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
