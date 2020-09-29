using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.ActivityLog
{
    public class UpdateActivityLogCommand : UpdateCommandBase<ActivityLogDto>
    {
        public UpdateActivityLogCommand()
        {

        }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("libelle")]
        public string Libelle { get; set; }
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
