using Newtonsoft.Json;
using Seamless.Model;
using Seamless.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Domain.Commands.Category
{
    public class UpdateCategoryCommand : UpdateCommandBase<CategoryDto>
    {
        public UpdateCategoryCommand()
        {

        }
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
        public bool Status { get; set; }
    }
}
