namespace RealEstate.core
{
    public class Agency
    {
        public Guid AgencyId { get; set; }
        public string AgencyName { get; set; } = string.Empty;
        public string AgencyPincode { get; set; }
        public Guid BrandId { get; set; }
        public bool IsDeleted { get; set; } = false; // Soft delete flag
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Audit column
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Audit column

        // Method to print agency details
        public void GetDetails()
        {
            Console.WriteLine($"ID: {AgencyId}, Name: {AgencyName}, BrandId: {BrandId}, Pincode: {AgencyPincode}, IsDeleted: {IsDeleted}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}");
        }
    }
}
    

