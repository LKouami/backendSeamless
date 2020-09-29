using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Seamless.Model.Dtos
{
    public  class NoteDto
    {
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
        public byte Status { get; set; }


        [JsonProperty("modifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("modifiedBy")]
        public int ModifiedBy { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("createdBy")]
        public int CreatedBy { get; set; }
    }
}
