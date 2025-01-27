using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.models
{
    public abstract class Property
    {

        public  Guid PropertyId { get; set; }
      
        
        public string Address { get; set; }


        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 99999999, ErrorMessage = "Price must be between 1 and 99,999,999.")]
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
