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
        }
    }
}
