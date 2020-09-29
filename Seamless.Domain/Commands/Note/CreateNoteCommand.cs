using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.Note
{
   public class CreateNoteCommand : CreateCommandBase<NoteDto>
    {
        public CreateNoteCommand() : base()
        {

        }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [JsonProperty("ticketId")]
        public long TicketId { get; set; }
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
