using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.AppParameter
{
    public class GetAppParameterQuery : GetOneQuery<long, AppParameterDto>
    {
        public GetAppParameterQuery(long Id) : base(Id)
        {

        }
    }
}
