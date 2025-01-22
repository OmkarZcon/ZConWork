using RealEstate.core;
using RealEstate.Core.Extensions;
using RealEstate.Core.Utilities;

class Program
{
    static void Main(string[] args)
    {
        List<Agency> agencies = new List<Agency>();

        // Get number of agencies from user
        Console.Write("\nEnter the number of agencies to add: ");
        int agencyCount = int.Parse(Console.ReadLine());

        // Input agencies
        for (int i = 0; i < agencyCount; i++)
        {
            Console.WriteLine($"\nEnter details for Agency #{i + 1}:");
            Console.Write("Agency Name: ");
            string agencyName = Console.ReadLine(); // Get agency name from user input

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

        // **Delegate Demonstration**: Calculate commission based on sale amount
        Console.WriteLine("\nEnter the sale amount to calculate commission:");
        decimal saleAmount = decimal.Parse(Console.ReadLine() ?? "0");

        // Select commission type
        Console.WriteLine("Choose commission type (1: Normal, 2: Premium):");
        int choice = int.Parse(Console.ReadLine() ?? "1");

        // Delegate selection for commission calculation
        CommissionDelegate commissionMethod = choice == 1 ? CommissionCalculator.NormalCommission : CommissionCalculator.PremiumCommission;

        // Calculate commission
        decimal commission = commissionMethod(saleAmount);
        Console.WriteLine($"Sale Amount: {saleAmount:C}, Commission: {commission:C}");
    }
}
