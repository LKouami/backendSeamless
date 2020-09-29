using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Seamless.Model.Dtos
{
    public class ActivityLogDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("userId")]
        public long UserId { get; set; }
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
