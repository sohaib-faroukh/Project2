using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.ViewModels
{
    public class OptionVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public int? Order { get; set; }

        // determine if this option is default option for this question
        public bool? IsDefault { get; set; }

    }
}
