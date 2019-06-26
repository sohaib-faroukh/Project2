using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Helpers
{
    public static class Helper
    {
        public static bool isAllCharsDigits(string String)
        {
            if (String.Length > 0)
            {
                foreach (char c in String)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
