namespace RealEstate.Core.Utilities
{

    public delegate decimal CommissionDelegate(decimal saleAmount);

    public static class CommissionCalculator
    {
        // Normal commission (5%)
        public static decimal NormalCommission(decimal saleAmount)
        {
            return saleAmount * 0.05m;
        }

        // Premium commission (10%)
        public static decimal PremiumCommission(decimal saleAmount)
        {
            return saleAmount * 0.1m;
        }
    }
}
