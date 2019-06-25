using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class Answer
    {
        [Key]
        public int Id { get; set; }


        // answer text
        public string Text { get; set; }

        // the survey response forign key
        public int SurveyResponseId { get; set; }
        [ForeignKey("SurveyResponseId")]
        public virtual SurveyResponse SurveyResponse { get; set; }


        // question that this is it's answer by specific customer forign key
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }


        public Answer() { }
        ~Answer() { }
    }
}
