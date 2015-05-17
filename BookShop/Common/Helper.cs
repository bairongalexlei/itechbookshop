using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Common
{
    public static class Helper
    {
        public static string TrimString(string strToTrim)
        {
            if (string.IsNullOrEmpty(strToTrim))
                return strToTrim;

            var resultString = strToTrim.Trim();
            return resultString;
        }
    }
}
