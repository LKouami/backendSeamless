using Newtonsoft.Json;
using System;

namespace Seamless.Model.Dtos
{
    public class UserDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("status")]
        public byte Status { get; set; }
        [JsonProperty("createdBy")]
        public int CreatedBy { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("modifiedBy")]
        public int ModifiedBy { get; set; }
        [JsonProperty("modifiedAt")]
        public DateTime ModifiedAt { get; set; }
        [JsonProperty("deletedBy")]
        public int? DeletedBy { get; set; }
        [JsonProperty("deletedAt")]
        public DateTime? DeletedAt { get; set; }
    }
}