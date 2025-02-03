namespace RealEstate.Core.Utilities
{

    public delegate decimal CommissionDelegate(decimal saleAmount);

    public interface ICommissionCalculator
    {
        decimal CalculateCommission(decimal saleAmount);
    }
}
