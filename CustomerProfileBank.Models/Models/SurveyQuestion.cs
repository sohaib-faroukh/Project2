using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{

    // Association table between Survey & Question Tables
    public class SurveyQuestion
    {
        [Key]
        public int Id { get; set; }


        // Question show order in this survey
        [Required]
        public int Order { get; set; }


        // is it reqired to answer this question in this survey
        [Required]
        public bool IsMandatory { get; set; }


        // survey forgin key
        [Required]
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }


        // question forgin key
        [Required]
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }


    }
}
