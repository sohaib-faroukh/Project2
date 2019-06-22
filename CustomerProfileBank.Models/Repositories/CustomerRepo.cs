using CustomerProfileBank.Models.Models;
using CustomerProfileBank.Models.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerProfileBank.Models.Context;
namespace CustomerProfileBank.Models.Repositories
{
   public class CustomerRepo: GeneralRepository<DataBaseContext, Customer>
    {
    }
}
