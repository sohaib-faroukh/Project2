using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }


        [Required]
        [MaxLength(150)]
        [Index(IsUnique =true)]
        public string NationalNumber { get; set; }



        [Required]
        [MaxLength(150)]
        public string Address { get; set; }


        [MaxLength(150)]
        public string ISPN { get; set; }


        [Required]
        [MaxLength(150)]
        public string Status { get; set; }

        public virtual ICollection<CustomerHobby> Hobbies { get; set; }
        public virtual ICollection<Number> Numbers { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        public Customer() { }
        ~Customer(){ }
    }
}
