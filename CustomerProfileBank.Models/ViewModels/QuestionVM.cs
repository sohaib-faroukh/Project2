using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.ViewModels
{
    public class QuestionVM
    {
        [Key]
        public int Id { get; set; }


        // Question show order in this survey
        [Required]
        public int Order { get; set; }


        // is it reqired to answer this question in this survey
        [Required]
        public bool IsMandatory { get; set; }

        // question text which will show when ask the question
        [Required]
        [MaxLength(250)]
        public string Text { get; set; }

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

    }
}
