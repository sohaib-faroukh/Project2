using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class ServiceType
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [Index(IsUnique = true)]
        [MaxLength(150)]
        public string Name { get; set; }


        public ServiceType() { }
        ~ServiceType() { }
    }
}
