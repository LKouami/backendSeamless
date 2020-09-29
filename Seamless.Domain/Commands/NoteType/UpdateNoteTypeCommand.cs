using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.NoteType
{
    public class UpdateNoteTypeCommand : UpdateCommandBase<NoteTypeDto>
    {
        public UpdateNoteTypeCommand()
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
