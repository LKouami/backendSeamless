using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.AppParameter
{
    public class GetAppParametersQuery : QueryListBase<PagedResults<AppParameterDto>>
    {
        public GetAppParametersQuery() : base()
        {

        }
        public GetAppParametersQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
