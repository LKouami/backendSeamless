using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.Faq
{
    public class UpdateFaqCommand : UpdateCommandBase<FaqDto>
    {
        public UpdateFaqCommand()
        {

        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
