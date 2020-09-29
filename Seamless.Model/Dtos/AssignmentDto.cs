using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Seamless.Model.Dtos
{
    public  class AssignmentDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("ticketId")]
        public long TicketId { get; set; }
        [JsonProperty("closedDate")]
        public DateTime? ClosedDate { get; set; }
        [JsonProperty("closedUserId")]
        public string ClosedUserId { get; set; }
        [JsonProperty("closeReasonId")]
        public int? CloseReasonId { get; set; }
        [JsonProperty("assigneeId")]
        public long? AssigneeId { get; set; }
        [JsonProperty("assignerId")]
        public long? AssignerId { get; set; }
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
