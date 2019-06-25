using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class FingerPrintClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Index(IsUnique =true)]
        public string Name { get; set; }

        public FingerPrintClass() { }
        ~FingerPrintClass() { }
    }
}
