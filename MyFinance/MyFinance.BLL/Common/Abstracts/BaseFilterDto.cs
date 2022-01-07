#nullable enable
using Newtonsoft.Json;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseFilterDto: BaseDto
    {
        [JsonProperty("limit", Required = Required.Default)]
        public long? Limit { get; set; }

        [JsonProperty("offset", Required = Required.Default)]
        public long? Offset { get; set; }

        [JsonProperty("orderBy", Required = Required.Default)]
        public string? OrderBy { get; set; }
    }
}
