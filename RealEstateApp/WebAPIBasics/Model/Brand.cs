using Sieve.Attributes;

namespace RealEstate.Api.Model
{
    public class Brand
    {

        public Guid BrandId { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string BrandName { get; set; }


    }
}
