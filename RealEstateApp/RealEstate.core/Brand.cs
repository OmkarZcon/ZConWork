namespace RealEstate.core
{
    public class Brand
    {
      
        public Guid BrandId { get; set; }
        
        
        public string BrandName { get; set; }

        

        // Method to print brand details
        public void GetDetails()
        {
            Console.WriteLine($"ID: {BrandId}, Name: {BrandName}");
        }
    }
}
