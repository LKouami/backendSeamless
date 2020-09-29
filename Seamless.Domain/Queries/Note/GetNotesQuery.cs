using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Note
{
    public class GetNotesQuery : QueryListBase<PagedResults<NoteDto>>
    {
        public GetNotesQuery() : base()
        {

        }
        public GetNotesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}
