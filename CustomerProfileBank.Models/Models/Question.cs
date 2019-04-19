using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int IsActive { get; set; }
        public DateTime Updated { get; set; }
        public Question() { }
        ~Question() { }
    }
}
