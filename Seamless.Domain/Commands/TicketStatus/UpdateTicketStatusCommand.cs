using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.TicketStatus
{
    public class UpdateTicketStatusCommand : UpdateCommandBase<TicketStatusDto>
    {
        public UpdateTicketStatusCommand()
        {

        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
