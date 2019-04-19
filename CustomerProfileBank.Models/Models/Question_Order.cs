using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Question_Order
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public Question_Order() { }
        ~Question_Order() { }
    }
}
