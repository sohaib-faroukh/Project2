using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Option
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        public int? Order { get; set; }

        // determine if this option is default option for this question
        public bool? IsDefault { get; set; }


        // ParentQuestion forgin key
        [Required]
        public int ParentQuestionId { get; set; }
        [ForeignKey("ParentQuestionId")]
        public Question ParentQuestion { get; set; }


        // Questions that will shows when choose this option as the answer 
        public ICollection<Question> Questions { get; set; }




    }
}
