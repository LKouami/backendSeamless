using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Seamless.Model.Dtos
{
    public  class TicketDto
    {
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
