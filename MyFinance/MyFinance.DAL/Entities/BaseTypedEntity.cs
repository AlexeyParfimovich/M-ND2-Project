using Newtonsoft.Json;

namespace MyFinance.DAL.Entities
{
    public abstract class BaseTypedEntity<T>: BaseEntity
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public T Id { get; set; }
    }
}
