using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int IsActive { get; set; }
        public int ManagerId { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public User() { }
        ~User() { }
    }
}
