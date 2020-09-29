using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.User
{
    public class GetUserQuery : GetOneQuery<long, UserDto>
    {
        public GetUserQuery(long Id) : base(Id)
        {

        }
    }
}
