using Artezire.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class BlobType : BaseEntity
    {
        public BlobTypeEnum BlobTypeCode { get; set; }
        public string BlobTypeDescription { get; set; }
    }
}
