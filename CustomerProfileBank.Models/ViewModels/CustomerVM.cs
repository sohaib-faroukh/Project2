using CustomerProfileBank.Models.Helpers;
using CustomerProfileBank.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ISPN { get; set; }
        public string Status { get; set; }
        public virtual ICollection<CustomerHobby> Hobbies { get; set; }
        public virtual ICollection<Number> Numbers { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        public CustomerVM() { }

        // For all proprties in the class
        public CustomerVM(int Id, string FirstName, string LastName, string Address, string ISPN, string Status,
            List<CustomerHobby> Hoppies,
            List<Number> Numbers,
            List<Service> Services)
        {
            this.Id = Id;
            this.FirstName = FirstName?.Trim();
            this.LastName = LastName?.Trim();
            this.Address = Address?.Trim().ToLower();
            this.Hobbies = Hoppies;
            this.Services = Services;
            this.Numbers = Numbers;

            if (Helper.isAllCharsDigits(ISPN))
            { this.ISPN = ISPN; }


            this.Status = Status?.Trim().ToUpper();

        }

        // For Essential information only
        public CustomerVM(string FirstName, string LastName, string Address)
        {
            this.FirstName = FirstName?.Trim();
            this.LastName = LastName?.Trim();
            this.Address = Address?.Trim().ToLower();

        }

        ~CustomerVM() { }

        // overload
        public static implicit operator Customer(CustomerVM value)
        {
            Customer result = new Customer();
            if (value.Id != 0)
            {
                result.Id = value.Id;
            }
            result.FirstName = value?.FirstName?.Trim();
            result.LastName = value?.LastName?.Trim();
            result.Address = value?.Address?.Trim();
            result.Hobbies= value?.Hobbies;
            result.Services = value?.Services;
            result.Numbers = value?.Numbers;

            if (value.ISPN != null && Helper.isAllCharsDigits(value.ISPN))
            {
                result.ISPN = value.ISPN;
            }
            return result;
        }
    }
}
