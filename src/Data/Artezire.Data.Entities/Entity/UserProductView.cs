using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class UserProductView
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int NoOfViews { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime FirstViewedOn { get; set; }
        public DateTime LastViewedOn { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
