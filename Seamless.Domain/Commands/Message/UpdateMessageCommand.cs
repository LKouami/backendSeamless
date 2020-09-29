using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.Message
{
    public class UpdateMessageCommand : UpdateCommandBase<MessageDto>
    {
        public UpdateMessageCommand()
        {

        }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [JsonProperty("ticketId")]
        public long TicketId { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
