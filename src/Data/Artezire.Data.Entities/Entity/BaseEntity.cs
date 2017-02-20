using System;
using System.ComponentModel.DataAnnotations;

namespace Artezire.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime? CreateDate { get; set; }
        
        public DateTime? UpdateDate { get; set; }
    }
}
