using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Category
{
    public class GetCategoriesQuery : QueryListBase<PagedResults<CategoryDto>>
    {
        public GetCategoriesQuery() : base()
        {

        }
        public GetCategoriesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
