using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }

        // word carry survey uniqe name
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }



        // sentence represent what this survey for and what's
        [MaxLength(250)]
        public string Description { get; set; }




        // creation survey time
        public DateTime CreationDate { get; set; }




        // how many months this survey will stil valid
        public int ValidiatyMonthlyPeriod { get; set; }




        // survey avtive period 
        // FromDate = null if the survey status is inactive
        // toDate = null if ToDate = null
        // toDate = null that means the survey always active until dynamicly deactivate it 

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }





        // survey current status "active,inactive,pendding,..."
        [Required]
        [MaxLength(100)]
        public string Status { get; set; }
        





        // User who have created the survey forign key
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }




        // survey has one or several questions
        public virtual ICollection<SurveyQuestion> Questions { get; set; }

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }



        public Survey() { }
        ~Survey() { }
    }
}
