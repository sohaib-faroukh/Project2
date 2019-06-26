using CustomerProfileBank.Models.Context;
using CustomerProfileBank.Models.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Repositories
{
    public class QuestionRepo : GeneralRepository<DataBaseContext, QuestionRepo>
    {
    }
}
