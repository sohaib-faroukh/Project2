using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Survey_Response
    {
        public int Id { get; set; }
        public DateTime Updated { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public Survey_Response() { }
        ~Survey_Response() { }
    }
}
