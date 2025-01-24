using System;
using System.Collections.Generic;
using System.Linq;
using RealEstate.core;

public class BrandRepository
{
    private static List<Brand> _brands = new List<Brand>();

    // Add a brand
    public void AddBrand(string name)
    {
        var brand = new Brand
        {
            Id = _brands.Count > 0 ? _brands.Max(b => b.Id) + 1 : 1,
            BrandName = name, // Fixed property name
            UniqueCode = GenerateUniqueCode(),
            CreatedAt = DateTime.UtcNow
        };
        _brands.Add(brand);
        Console.WriteLine($"Brand '{name}' added with Unique Code '{brand.UniqueCode}'.");
    }

    // Get all active brands
    public void GetAllBrands()
    {
        var brands = _brands.Where(b => !b.IsDeleted).ToList();
        if (brands.Any())
        {
            Console.WriteLine("Active Brands:");
            foreach (var brand in brands)
            {
                Console.WriteLine($"Id: {brand.Id}, Name: {brand.BrandName}, UniqueCode: {brand.UniqueCode}, CreatedAt: {brand.CreatedAt}");
            }
        }
        else
        {
            Console.WriteLine("No active brands found.");
        }
    }

    // Update a brand
    public void UpdateBrand(int id, string newName)
    {
        var brand = _brands.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
        if (brand != null)
        {
            brand.BrandName = newName; // Fixed property name
            brand.UpdatedAt = DateTime.UtcNow;
            Console.WriteLine($"Brand with Id {id} updated to Name '{newName}'.");
        }
        else
        {
            Console.WriteLine($"Brand with Id {id} not found or is deleted.");
        }
    }

    // Soft delete a brand
    public void DeleteBrand(int id)
    {
        var brand = _brands.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
        if (brand != null)
        {
            brand.IsDeleted = true;
            brand.DeletedAt = DateTime.UtcNow;
            Console.WriteLine($"Brand with Id {id} soft-deleted.");
        }
        else
        {
            Console.WriteLine($"Brand with Id {id} not found or is already deleted.");
        }
    }

    // Generate unique code
    private string GenerateUniqueCode()
    {
        return $"BRAND-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
    }
}
