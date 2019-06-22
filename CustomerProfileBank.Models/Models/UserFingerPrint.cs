using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class UserFingerPrint
    {
        public int Id { get; set; }
        public string FingerPrint { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FingerPrintClassId { get; set; }
        public FingerPrintClass FingerPrintClass { get; set; }
        public UserFingerPrint() { }
        ~UserFingerPrint() { }
    }
}
