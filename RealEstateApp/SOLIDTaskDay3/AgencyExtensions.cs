namespace RealEstate.Core.Extensions
{
    public static class AgencyExtensions
    {
        // Extension method to check if the agency name contains "Realty"
        public static bool IsValidAgencyName(this string agencyName)
        {
            return agencyName.Contains("Realty", StringComparison.OrdinalIgnoreCase);
        }
    }
}
