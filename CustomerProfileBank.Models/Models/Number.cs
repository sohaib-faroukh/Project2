using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class Number
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; } 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int NumberTypeId { get; set; }
        public NumberType NumberType { get; set; }

        public Number() { }
        ~Number() { }
    }
}
