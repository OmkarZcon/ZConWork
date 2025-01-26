using System;

class Program
{
    static void Main(string[] args)
    {
        var repository = new ProductRepository();

       


        // Add products
        repository.AddProduct("Laptop");
        repository.AddProduct("Smartphone");
        repository.AddProduct("Tablet");

        // Display all active products
        Console.WriteLine("\n-- Displaying all active products --");
        repository.GetAllProducts();

        // Soft delete a product
        Console.WriteLine("\n-- Soft deleting Product with Id 1 --");
        repository.DeleteProduct(1);

        // Display all active products after deletion
        Console.WriteLine("\n-- Displaying all active products after deletion --");
        repository.GetAllProducts();

        // Display all soft-deleted products
        Console.WriteLine("\n-- Displaying soft-deleted products --");
        repository.GetDeletedProducts();
    }
}
