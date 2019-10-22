using System;
using System.Collections.Generic;
using System.Text;

namespace Structs.Task3
{
    public static class Extensions
    {
        public static string GetMonth(this Month month, int n)
        {
            if(n >= 0 && n < 12)
                return Enum.GetName(typeof(Month), n);
            return "n must be >= 0 && < 12";
        }
        
    }
}
