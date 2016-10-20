using System;
using System.ComponentModel.DataAnnotations;

namespace Artezire.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
    }
}
