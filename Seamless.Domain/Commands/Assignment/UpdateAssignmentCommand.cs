using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.Assignment
{
    public class UpdateAssignmentCommand : UpdateCommandBase<AssignmentDto>
    {
        public UpdateAssignmentCommand()
        {

        }
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
        public bool Status { get; set; }
    }
}
