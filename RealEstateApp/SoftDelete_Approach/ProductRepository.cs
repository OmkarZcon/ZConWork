using System;
using System.Collections.Generic;
using System.Linq;
public class ProductRepository
{
    private static List<Product> _products = new List<Product>();
    private static int _nextId = 1;

    // Add a product
    public void AddProduct(string name)
    {
        var product = new Product
        {
            Id = _nextId++,
            Name = name,
            UniqueCode = GenerateUniqueCode(name),
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow
        };
        _products.Add(product);
        Console.WriteLine($"Product '{name}' added with Unique Code '{product.UniqueCode}'.");
    }

    // Soft delete a product
    public void DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        if (product != null)
        {
            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow;
            Console.WriteLine($"Product with Id {id} soft-deleted.");
        }
        else
        {
            Console.WriteLine($"Product with Id {id} not found or is already deleted.");
        }
    }

    // Get all active products
    public void GetAllProducts()
    {
        var products = _products.Where(p => !p.IsDeleted).ToList();
        if (products.Any())
        {
            Console.WriteLine("Active Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, UniqueCode: {product.UniqueCode}, CreatedAt: {product.CreatedAt}");
            }
        }
        else
        {
            Console.WriteLine("No active products found.");
        }
    }

    // Get all soft-deleted products
    public void GetDeletedProducts()
    {
        var deletedProducts = _products.Where(p => p.IsDeleted).ToList();
        if (deletedProducts.Any())
        {
            Console.WriteLine("Soft-Deleted Products:");
            foreach (var product in deletedProducts)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, UniqueCode: {product.UniqueCode}, DeletedAt: {product.DeletedAt}");
            }
        }
        else
        {
            Console.WriteLine("No soft-deleted products found.");
        }
    }

    // Generate a unique code
    private string GenerateUniqueCode(string name)
    {
        return $"PRODUCT-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
    }
}
