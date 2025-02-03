using RealEstate.Core.Utilities;

namespace SOLIDTaskDay3
{
    public class NormalCommissionCalculator : ICommissionCalculator
    {
        public decimal CalculateCommission(decimal saleAmount)
        {
            return saleAmount * 0.05m; // Normal commission (5%)
        }
    }
}
