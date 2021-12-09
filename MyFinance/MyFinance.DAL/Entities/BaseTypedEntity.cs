using System.ComponentModel.DataAnnotations;

namespace MyFinance.DAL.Entities
{
    public abstract class BaseTypedEntity<T>: BaseEntity
    {
        [Required]
        public T Id { get; set; }
    }
}
