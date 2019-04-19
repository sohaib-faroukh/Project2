using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Updated { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public Survey() { }
        ~Survey() { }
    }
}
