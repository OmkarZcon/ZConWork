using RealEstate.core;
using RealEstate.Core.Extensions;
using RealEstate.Core.Utilities;
using SOLIDTaskDay3;

class Program
{
    static void Main(string[] args)
    {
        List<Agency> agencies = new List<Agency>();


        // ----------------------Agency Validity Check--------------------------------
        // Get number of agencies from user 

        Console.Write("\nEnter the number of agencies to add: ");
        int agencyCount = int.Parse(Console.ReadLine());

        var agencyIndices = Enumerable.Range(1, agencyCount);

        foreach (var index in agencyIndices)
        {
            Console.WriteLine($"\nEnter details for Agency #{index}:");
            Console.Write("Agency Name: ");
            string agencyName = Console.ReadLine();

            Console.Write("Agency Pincode: ");
            string agencyPincode = Console.ReadLine();

            agencies.Add(new Agency
            {
                AgencyId = Guid.NewGuid(),
                AgencyName = agencyName,
                AgencyPincode = agencyPincode ?? string.Empty
            });
        }

        Console.WriteLine("\nAgency Validity Check:");
        foreach (var agency in agencies)
        {
            bool isValid = agency.AgencyName.IsValidAgencyName();
            Console.WriteLine($"{agency.AgencyName} is valid: {isValid}");
        }


        // ------------------------------------------Commission Calculator-----------------------------

        Console.WriteLine("Enter the sale Amount to caluculate the commission: ");
        decimal saleAmount = decimal.Parse(Console.ReadLine());


        Console.WriteLine("Chhose commsion type ( 1: Normal , 2: Premium): ");
        int choice = int.Parse(Console.ReadLine());

        ICommissionCalculator commsionCalculator = choice switch
        {

            1 => new NormalCommissionCalculator(),
            2 => new PremiumCommissionCalculator(),

            _ => throw new ArgumentException("Inavlid commsion type")


        };

        decimal commission = commsionCalculator.CalculateCommission(saleAmount);
        Console.WriteLine($"Sale Amount: {saleAmount:C} , Commission: {commission:C}");
    }
}
