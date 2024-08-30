using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore
{
    public static class DecimalExtensions
    {
        public static decimal ToDecimal(decimal value)
        { 
            return value * .9M; 
            // Need to specify that .9 is a decimal value with the M (money) as decimals are preffered when using money because they are more concise that the default double.

        }
    }
}
