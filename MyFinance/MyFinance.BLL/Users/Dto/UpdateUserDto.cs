using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;
using System;

namespace MyFinance.BLL.Users.Dto
{
    public class UpdateUserDto: BaseDto
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public Guid Id { get; set; }

        [JsonProperty("userName", Order = 1, Required = Required.Default)]
        public string UserName { get; set; }

        [JsonProperty("email", Order = 2, Required = Required.Default)]
        public string Email { get; set; }
    }
}
