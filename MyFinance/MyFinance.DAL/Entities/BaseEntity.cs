#nullable enable
using System;
using System.ComponentModel.DataAnnotations;

namespace MyFinance.DAL.Entities
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedAt { get; set; }

        [MaxLength(32)]
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [MaxLength(32)]
        public string? UpdatedBy { get; set; }
    }
}
