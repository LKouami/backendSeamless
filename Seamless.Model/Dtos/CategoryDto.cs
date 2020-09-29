using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Seamless.Model.Dtos
{
    public  class CategoryDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("parentId")]
        public int ParentId { get; set; }
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
