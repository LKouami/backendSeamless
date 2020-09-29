using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Category
{
    public class GetCategoryQuery : GetOneQuery<long, CategoryDto>
    {
        public GetCategoryQuery(long Id) : base(Id)
        {

        }
    }
}
