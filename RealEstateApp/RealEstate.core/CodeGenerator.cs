namespace RealEstate.core
{
    public static class CodeGenerator
    {
        public static string GenerateUniqueCode(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var uniqueCode = new string(Enumerable.Range(0, length)
                                  .Select(_ => chars[random.Next(chars.Length)])
                                  .ToArray());
            return uniqueCode; 
        }
    }
}
