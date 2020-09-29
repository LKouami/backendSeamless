using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.Note
{
    public class GetNoteQuery : GetOneQuery<long, NoteDto>
    {
        public GetNoteQuery(long Id) : base(Id)
        {

        }
    }
}
