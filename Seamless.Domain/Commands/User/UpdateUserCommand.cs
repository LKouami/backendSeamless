using Seamless.Model.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Seamless.Domain.Commands.User
{
    public class UpdateUserCommand : UpdateCommandBase<UserDto>
    {

        public UpdateUserCommand()
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