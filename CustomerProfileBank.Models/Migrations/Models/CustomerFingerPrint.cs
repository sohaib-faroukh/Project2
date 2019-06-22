using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class CustomerFingerPrint
    {
        public int Id { get; set; }
        public string FingerPrint { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int FingerPrintClassId { get; set; }
        public FingerPrintClass FingerPrintClass { get; set; }
        public CustomerFingerPrint() { }
        ~CustomerFingerPrint() { }

    }
}
