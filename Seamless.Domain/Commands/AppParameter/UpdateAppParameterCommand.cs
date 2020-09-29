using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.AppParameter
{
    public class UpdateAppParameterCommand : UpdateCommandBase<AppParameterDto>
    {
        public UpdateAppParameterCommand()
        {

        }
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
        public bool Status { get; set; }
    }
}
