using System;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UniqueCode { get; set; }
    public bool IsDeleted { get; set; } // Soft delete flag
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; } // Tracks when the product was deleted
}
