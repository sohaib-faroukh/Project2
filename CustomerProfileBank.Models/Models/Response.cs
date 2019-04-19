using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
   public class Response
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int Survey_ResponseId { get; set; }
        public virtual Survey_Response Survey_Response { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Response() { }
        ~Response() { }
    }
}
