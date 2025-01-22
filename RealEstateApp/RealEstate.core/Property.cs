namespace RealEstate.Core.models
{
    public abstract class Property
    {

        public int PropertyId { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }


        public Property(int propertyId, string address, decimal price)
        {
            PropertyId = propertyId;
            Address = address;
            Price = price;
        }


        public abstract string GetDetails();
    }
}
