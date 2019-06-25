using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class Number
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique =true)]
        public string PhoneNumber { get; set; }


        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }



        public int NumberTypeId { get; set; }
        [ForeignKey("NumberTypeId")]
        public virtual NumberType NumberType { get; set; }


        public Number() { }
        ~Number() { }
    }
}
