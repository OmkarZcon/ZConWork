using System.ComponentModel.DataAnnotations;
using OOPTaskDay2;
using RealEstate.core;
using Serilog;
namespace RealEstate.Core.models;

class Program
{
    static void Main()
    {



        // Create lists to store properties
        List<Property> properties = new List<Property>();

        Console.Write("Enter the number of properties to add: ");
        int propertyCount = int.Parse(Console.ReadLine());

        // Input loop for properties
        for (int counter = 0; counter < propertyCount; counter++)
        {
            Console.WriteLine($"\nProperty #{ + 1}");
            Console.Write("Enter property type (1 for Residential, 2 for Commercial): ");
            int propertyType = int.Parse(Console.ReadLine());

           
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

           // Exception Handling for Price
            decimal price;
            try
            {
                Console.Write("Enter Price: ");
                price = decimal.Parse(Console.ReadLine());

                if (price <= 0)
                {
                    throw new InvalidPriceException("Price must be greater than 0.");
                }
            }
            catch (FormatException ex)
            {
                Log.Error(ex, "Invalid price format. Please enter a valid number.");
                Console.WriteLine("Invalid price. Please enter a valid number.");
                counter--;
                continue;
            }
            catch (InvalidPriceException ex)
            {
                Log.Error(ex, "Price must be greater than 0.");
                Console.WriteLine("Enter a number greater than 0.");
                counter--; 
                continue;
            }




            // Create property object
            Property property;
            if (propertyType == 1)
            {
                property = new ResidentialProperty( address, price);
            }
            else
            {
                property = new CommercialProperty( address, price);
            }

            // Add to list
            properties.Add(property);





        }
        // Create printer object
        var propertyPrinter = new PropertyPrinter();



        // Display all properties
        Console.WriteLine("\n=== Property Details ===");
        foreach (var property in properties)
        {
            var details = property.GetDetails();
            propertyPrinter.PrintPropertyDetails(details);

            // Calculate and display tax for each property
            decimal propertyPrice = property.Price;
            decimal propertyTax;

            PropertyTaxCalculator.CalculateTax(ref propertyPrice, out propertyTax);
            
            var taxDetails = propertyPrinter.PrintTaxDetails(propertyPrice, propertyTax);
            Console.WriteLine(taxDetails);
            Console.WriteLine("------------------------");
        }

        // Calculate total portfolio value
        decimal totalValue = properties.Sum(p => p.Price);
        Console.WriteLine($"\nTotal Portfolio Value: {totalValue:C}");


        // Property type statistics
        int residentialCount = properties.Count(p => p is ResidentialProperty);
        int commercialCount = properties.Count(p => p is CommercialProperty);

        Console.WriteLine($"\nPortfolio Statistics:");
        Console.WriteLine($"Total Properties: {properties.Count}");
        Console.WriteLine($"Residential Properties: {residentialCount}");
        Console.WriteLine($"Commercial Properties: {commercialCount}");





        // Prints the details of the properties ( Reflections )
        PropertyInspector.TestReflection();




        Console.Write("\nEnter the minimum price to filter properties: ");
        decimal minPrice = decimal.Parse(Console.ReadLine());






        // Filter properties by price -- LINQ
        var filteredProperties = properties.Where(p => p.Price >= minPrice);

        Console.WriteLine($"\nProperties with price >= {minPrice:C}:");
        foreach (var property in filteredProperties)
        {
            Console.WriteLine(property.GetDetails());
        }



        // Grouping properties by type -- LINQ
        var groupedProperties = properties.GroupBy(p => p.GetType().Name);

        Console.WriteLine("\nProperties grouped by type:");
        foreach (var group in groupedProperties)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var property in group)
            {
                Console.WriteLine($"   {property.Address}, Price: {property.Price:C}");
            }
        }



    }


    public static void ValidateAndThrow(object model)
    {
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, true);

        if (!isValid)
        {
            // Collect all error messages
            var errorMessages = string.Join(Environment.NewLine, results.ConvertAll(result => result.ErrorMessage));
            throw new Exception(errorMessages);
        }
    }
}

public class PropertyPrinter
{
    public void PrintPropertyDetails(string propertyDetails)
    {
        Console.WriteLine($"Property Details: {propertyDetails}");
    }

    public string PrintTaxDetails(decimal price, decimal tax)
    {
        return $"Updated Price: {price:C}, Tax Amount: {tax:C}";
    }
}

