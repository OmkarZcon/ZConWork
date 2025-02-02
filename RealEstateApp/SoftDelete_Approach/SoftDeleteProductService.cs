using System;

public class SoftDeleteProductService
{
    public void SoftDeleteProduct(ProductRepository repository)
    {
        Console.Write("Enter  Product Id to soft delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid input. Please enter a valid product Id.");
            return;
        }
        ;
        repository.DeleteProduct(id);
    }
}
