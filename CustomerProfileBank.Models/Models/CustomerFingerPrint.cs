using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class CustomerFingerPrint
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FingerPrint { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int FingerPrintClassId { get; set; }
        [ForeignKey("FingerPrintClassId")]
        public FingerPrintClass FingerPrintClass { get; set; }

        public CustomerFingerPrint() { }
        ~CustomerFingerPrint() { }

    }
}
