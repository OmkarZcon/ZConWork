namespace RealEstateApp.Models
{
    public class Brand
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }

        public Brand()
        {
            BrandId = Guid.NewGuid();
        }


        // Method to print brand details
        public void GetDetails()
        {
            Console.WriteLine($"ID: {BrandId}, Name: {BrandName}");
        }
    }
}
