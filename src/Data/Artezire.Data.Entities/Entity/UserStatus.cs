using Artezire.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Entities
{
    public class UserStatus : BaseEntity
    {
        public UserStatusEnum UserStatusCode { get; set; }
        public string UserStatusDescription { get; set; }
    }
}
