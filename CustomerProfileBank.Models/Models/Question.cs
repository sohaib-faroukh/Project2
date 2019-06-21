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

        // foregin key on parentQuestion 
        public int ParentQuestionId { get; set; }
        [ForeignKey("ParentQuestionId")]
        public virtual Question ParentQuestion { get; set; }


        // foregin key on parentOption 
        public int ParentOptionId { get; set; }
        [ForeignKey("ParentOptionId")]
        public virtual Option ParentOption { get; set; }

        // question text which will show when ask the question
        public string Type
        {
            get { return Type; }
            set
            {
                if (this.Type != null)
                {
                    this.Type = this.Type.Trim().ToUpper();
                }
                else
                {
                    throw new Exception("Type can't be null");
                }
            }
        }


        // question current status "active,inactive,pendding,..."
        public string Status
        {
            get { return Status; }
            set
            {
                if (this.Status != null)
                {
                    this.Status = this.Status.Trim().ToUpper();
                }
                else
                {
                    throw new Exception("Status can't be null");
                }
            }
        }

        // qustion maybe existing in one or more survey
        public virtual ICollection<SurveyQuestion> Surveys { get; set; }

        public virtual ICollection<Option> Options { get; set; }


        public Question() { }

        ~Question() { }
    }
}
