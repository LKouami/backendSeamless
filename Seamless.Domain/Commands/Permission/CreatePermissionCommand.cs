using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.Permission
{
   public class CreatePermissionCommand : CreateCommandBase<PermissionDto>
    {
        public CreatePermissionCommand() : base()
        {

        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("parentId")]
        public int? ParentId { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
