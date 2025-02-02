using System;

class Program
{
    static void Main(string[] args)
    {
        var repository = new ProductRepository();
        var addProductService = new AddProductService();
        var softDeleteService = new SoftDeleteProductService();

        while (true)
        {
            Console.WriteLine("\n--- Product Repository Menu ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Display All Active Products");
            Console.WriteLine("3. Soft Delete Product");
            Console.WriteLine("4. Display Soft-Deleted Products");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    addProductService.AddProduct(repository);
                    break;

                case 2:
                    repository.GetAllProducts();
                    break;

                case 3:
                    softDeleteService.SoftDeleteProduct(repository);
                    break;

                case 4:
                    repository.GetDeletedProducts();
                    break;

                case 5:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

   
}
