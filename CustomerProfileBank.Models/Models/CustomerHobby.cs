using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class CustomerHobby
    {
        [Key]
        public int Id { get; set; }

        
        public int HobbyTypeId { get; set; }
        [ForeignKey("HobbyTypeId")]
        public HobbyType HobbyType { get; set; }


        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public CustomerHobby() { }
        ~CustomerHobby() { }
    }
}
