using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Permission
{
    public class GetPermissionsQuery : QueryListBase<PagedResults<PermissionDto>>
    {
        public GetPermissionsQuery() : base()
        {

        }
        public GetPermissionsQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
