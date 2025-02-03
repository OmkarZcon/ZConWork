using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstate.Core.Utilities;

namespace SOLIDTaskDay3
{
    public class PremiumCommissionCalculator : ICommissionCalculator
    {
        public decimal CalculateCommission(decimal saleAmount)
        {
            return saleAmount * 0.10m; // Premium commission (10%)
        }
    }
}
