namespace RealEstate.Core.models
{
    public abstract class Property
    {

        public  Guid PropertyId { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }


        public Property( string address, decimal price)
        {
            PropertyId = Guid.NewGuid();
            Address = address;
            Price = price;
        }


        public abstract string GetDetails();
    }
}
