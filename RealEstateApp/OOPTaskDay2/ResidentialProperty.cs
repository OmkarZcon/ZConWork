namespace RealEstate.Core.models
{
    public class ResidentialProperty : Property
    {
             public ResidentialProperty( string address, decimal price) : base( address, price)
        {

        }

        public override string GetDetails()
        {
            return $"Residential Property - PropertyId: {PropertyId}, Address: {Address}, Price: {Price:C}";
        }
    }
}