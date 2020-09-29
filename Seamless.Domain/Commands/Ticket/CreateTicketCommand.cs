using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.Ticket
{
   public class CreateTicketCommand : CreateCommandBase<TicketDto>
    {
        public CreateTicketCommand() : base()
        {

        }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("parentId")]
        public int ParentId { get; set; }
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [JsonProperty("priorityId")]
        public int PriorityId { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("file")]
        public string File { get; set; }
        [JsonProperty("state")]
        public int State { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
