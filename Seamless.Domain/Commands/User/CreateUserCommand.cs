using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Seamless.Model.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Seamless.Domain.Commands.User
{
    public class CreateUserCommand : CreateCommandBase<UserDto>
    {
        public CreateUserCommand() : base()
        {

        }

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
    }    
}