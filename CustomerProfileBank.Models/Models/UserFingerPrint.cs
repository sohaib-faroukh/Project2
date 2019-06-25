using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class UserFingerPrint
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FingerPrint { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        public int FingerPrintClassId { get; set; }
        [ForeignKey("FingerPrintClassId")]
        public virtual FingerPrintClass FingerPrintClass { get; set; }


        public UserFingerPrint() { }
        ~UserFingerPrint() { }
    }
}
