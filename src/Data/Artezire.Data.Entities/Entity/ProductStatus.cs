using Artezire.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class ProductStatus : BaseEntity
    {
        public string ProductStatusDescription { get; set; }
        public ProductStatusEnum ProductStatusCode { get; set; }
    }
}
