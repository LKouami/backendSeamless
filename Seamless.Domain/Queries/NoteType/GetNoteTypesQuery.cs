using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.NoteType
{
    public class GetNoteTypesQuery : QueryListBase<PagedResults<NoteTypeDto>>
    {
        public GetNoteTypesQuery() : base()
        {

        }
        public GetNoteTypesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
