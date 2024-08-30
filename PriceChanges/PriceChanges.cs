using System.Runtime.CompilerServices;

namespace PriceChanges.Extensions 
{
    public static class PriceChanges
    {
        public static decimal DiscountThisPrice(this decimal discount)
        {
            return Math.Round(discount * .9M, 2);
        }
    }
}
