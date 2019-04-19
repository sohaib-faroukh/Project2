using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class Privilege
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int PrivilegeTypeId { get; set; }
        public virtual PrivilegeType PrivilegeType { get; set; }
        public Privilege() { }
        ~Privilege() { }
    }
}
