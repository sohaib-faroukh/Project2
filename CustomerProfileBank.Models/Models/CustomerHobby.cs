using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class CustomerHobby
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int HobbyTypeId { get; set; }
        public HobbyType HobbyType { get; set; }
        public CustomerHobby() { }
        ~CustomerHobby() { }
    }
}
