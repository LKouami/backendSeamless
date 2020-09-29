using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Permission
{
    public class GetPermissionQuery : GetOneQuery<long, PermissionDto>
    {
        public GetPermissionQuery(long Id) : base(Id)
        {

        }
    }
}
