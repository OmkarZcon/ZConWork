using RealEstate.core;
class Program
{
    static void Main(string[] args)
    {
        List<Brand> brands = new List<Brand>();
        List<Agency> agencies = new List<Agency>();

        // Get number of brands from user
        Console.Write("Enter the number of brands to add: ");
        int brandCount = int.Parse(Console.ReadLine());

        // Input brands
        for (int i = 0; i < brandCount; i++)
        {
            Console.WriteLine($"\nEnter details for Brand #{i + 1}:");
            Console.Write("Brand Name: ");
            string brandName = Console.ReadLine();

            brands.Add(new Brand
            {
                BrandId = Guid.NewGuid(),
                BrandName = brandName
            });
        }

        // Get number of agencies from user
        Console.Write("\nEnter the number of agencies to add: ");
        int agencyCount = int.Parse(Console.ReadLine());

        // Input agencies
        for (int i = 0; i < agencyCount; i++)
        {
            Console.WriteLine($"\nEnter details for Agency #{i + 1}:");
            Console.Write("Agency Name: ");
            string agencyName = Console.ReadLine();

            Console.Write("Agency Pincode: ");
            string agencyPincode = Console.ReadLine();

            // Show available brands
            Console.WriteLine("\nAvailable Brands:");
            for (int j = 0; j < brands.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {brands[j].BrandName}");
            }

            Console.Write("Select brand number: ");
            int brandIndex = int.Parse(Console.ReadLine()) - 1;

            agencies.Add(new Agency
            {
                AgencyId = Guid.NewGuid(),
                AgencyName = agencyName,
                AgencyPincode = agencyPincode,
                BrandId = brands[brandIndex].BrandId
            });
        }

        // Print all brands
        Console.WriteLine("\nBrands:");
        foreach (var brand in brands)
        {
            brand.GetDetails();
        }

        // Print all agencies 
        Console.WriteLine("\nAgencies:");
        foreach (var agency in agencies)
        {
            agency.GetDetails();
        }
    }
}



//Brand brandi = new Brand();
//brandi.GetDetails();


//Agency agent = new Agency();
//agent.GetDetails();


