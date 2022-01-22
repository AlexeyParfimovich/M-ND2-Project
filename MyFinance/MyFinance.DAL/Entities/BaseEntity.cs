#nullable enable
using Newtonsoft.Json;
using System;

namespace MyFinance.DAL.Entities
{
    public abstract class BaseEntity
    {
        [JsonIgnore]
        [JsonProperty("createdAt", Required = Required.Default)]
        public DateTime? CreatedAt { get; set; }

        [JsonIgnore]
        [JsonProperty("createdBy", Required = Required.Default)]
        public string? CreatedBy { get; set; }

        [JsonIgnore]
        [JsonProperty("updatedAt", Required = Required.Default)]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        [JsonProperty("updatedBy", Required = Required.Default)]
        public string? UpdatedBy { get; set; }
    }
}
