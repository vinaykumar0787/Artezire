using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class ProductBlob
    {
        public int ProductId { get; set; }
        public string BlobKey { get; set; }
        public string ContainerKey { get; set; }
        public int BlobTypeId { get; set; }

        public BlobType BlobType { get; set; }
    }
}
