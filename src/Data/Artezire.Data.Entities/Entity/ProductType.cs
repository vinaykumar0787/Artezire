using Artezire.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class ProductType : BaseEntity
    {
        public string ProductTypeName { get; set; }
        public string ProductTypeDescription { get; set; }
        public ProductTypeEnum ProductTypeCode { get; set; }
    }
}
