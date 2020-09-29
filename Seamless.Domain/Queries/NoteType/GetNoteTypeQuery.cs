using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Queries.NoteType
{
    public class GetNoteTypeQuery : GetOneQuery<long, NoteTypeDto>
    {
        public GetNoteTypeQuery(long Id) : base(Id)
        {

        }
    }
}
