using Artezire.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class UserType : BaseEntity
    {
        public UserTypeEnum UserTypeCode { get; set; }
        public string UserTypeDescription { get; set; }
    }
}
