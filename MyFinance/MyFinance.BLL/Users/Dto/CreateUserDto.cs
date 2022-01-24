using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;

namespace MyFinance.BLL.Users.Dto
{
    public class CreateUserDto: BaseDto
    {
        [JsonProperty("userName", Order = 1, Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty("email", Order = 2, Required = Required.Always)]
        public string Email { get; set; }
    }
}
