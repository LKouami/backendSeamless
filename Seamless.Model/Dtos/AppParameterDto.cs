using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Seamless.Model.Dtos
{
    public  class AppParameterDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("parameterName")]
        public string ParameterName { get; set; }
        [JsonProperty("section")]
        public string Section { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }
        [JsonProperty("TypeParameter")]
        public string TypeParameter { get; set; }
        [JsonProperty("valuesList")]
        public string ValuesList { get; set; }
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
