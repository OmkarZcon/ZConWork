namespace RealEstate.core
{
    public class Brand
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }

        public bool IsDeleted { get; set; } = false; // Soft delete flag
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Audit column
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Audit column
        public DateTime DeletedAt { get; set; }
       

        // Method to print brand details
        public void GetDetails()
        {
            Console.WriteLine($"ID: {BrandId}, Name: {BrandName}, IsDeleted: {IsDeleted}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}");
        }
    }
}
