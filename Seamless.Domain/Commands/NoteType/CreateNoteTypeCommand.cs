using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.NoteType
{
   public class CreateNoteTypeCommand : CreateCommandBase<NoteTypeDto>
    {
        public CreateNoteTypeCommand() : base()
        {

        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
