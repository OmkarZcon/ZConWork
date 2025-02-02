using System;

public class AddProductService
{
    public void AddProduct(ProductRepository repository)
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Product name cannot be empty.");
            return;
        }

        repository.AddProduct(name);
    }
}
