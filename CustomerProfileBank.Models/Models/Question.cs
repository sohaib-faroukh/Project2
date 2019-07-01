using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        // question text which will show when ask the question
        [Required]
        [MaxLength(250)]
        public string Text { get; set; }



        // question text which will show when ask the question
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }



        // question current status "active,inactive,pendding,..."
        [Required]
        [MaxLength(100)]
        public string Status { get; set; }


        // foregin key on parentQuestion 
        public int? ParentQuestionId { get; set; }
        [ForeignKey("ParentQuestionId")]
        public virtual Question ParentQuestion { get; set; }



        // foregin key on parentOption 
        public int? ParentOptionId { get; set; }
        [ForeignKey("ParentOptionId")]
        public virtual Option ParentOption { get; set; }





        // foregin key on CategoryId 
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId ")]
        public virtual Category Category { get; set; }




        // qustion maybe existing in one or more survey
        public virtual ICollection<SurveyQuestion> Surveys { get; set; }

        public virtual ICollection<Option> Options { get; set; }

            

        public Question() { }

        ~Question() { }
    }
}
