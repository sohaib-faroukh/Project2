using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int IsActive { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public Service() { }
        ~Service() { }
    }
}
