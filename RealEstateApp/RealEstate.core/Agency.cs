namespace RealEstate.core
{
    public class Agency
    {
        public Guid AgencyId { get; set; }
        public string AgencyName { get; set; } = string.Empty;
        public string AgencyPincode { get; set; }
        public Guid BrandId { get; set; }







        // Method to print agency details
        public void GetDetails()
        {
            Console.WriteLine($"ID: {AgencyId}, Name: {AgencyName}, BrandId: {BrandId}, Pincode: {AgencyPincode}");
        }
    }
}
