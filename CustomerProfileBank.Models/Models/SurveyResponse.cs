using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class SurveyResponse
    {
        [Key]
        public int Id { get; set; }

        public DateTime RespondDateTime { get; set; }

        // customer forign key
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        
        // survey forign key
        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }


        public SurveyResponse() { }
        ~SurveyResponse() { }
    }
}
