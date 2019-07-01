using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        // Category Name 
        [Required]
        [Index(IsUnique =true)]
        [MaxLength(100)]
        public string Name { get; set; }


        [MaxLength(250)]
        public string Description { get; set; }


        public int? ParentCategoryId { get; set; }

    }
}
