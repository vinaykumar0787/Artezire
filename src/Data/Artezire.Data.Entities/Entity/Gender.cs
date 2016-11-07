using Artezire.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class Gender : BaseEntity
    {
        public GenderEnum GenderCode { get; set; }
        public string Description { get; set; }
    }
}
