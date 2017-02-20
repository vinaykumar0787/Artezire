using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductStatusId { get; set; }
        public int NoOfLikes { get; set; }
        public double Price { get; set; }
        public string ProductUrl { get; set; }

        public ProductType ProductType { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
