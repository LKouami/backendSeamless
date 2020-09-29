using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.TicketField
{
   public class CreateTicketFieldCommand : CreateCommandBase<TicketFieldDto>
    {
        public CreateTicketFieldCommand() : base()
        {

        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("isRequired")]
        public int IsRequired { get; set; }
        [JsonProperty("choiceList")]
        public string ChoiceList { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
