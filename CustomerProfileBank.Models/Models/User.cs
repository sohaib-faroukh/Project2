using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace CustomerProfileBank.Models.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int HRId { get; set; }

        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Alias { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime? DeactivationDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public User() { }
        ~User() { }
    }
}
