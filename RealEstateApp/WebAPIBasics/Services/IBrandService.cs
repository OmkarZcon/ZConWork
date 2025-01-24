namespace RealEstate.Api.Services
{
    public interface IBrandService
    {


        //method Signatures..

        List<string> GetAllBrands();
        string CreateBrand(string brandName);
        string UpdateBrand(int id, string brandName);
        bool DeleteBrand(int id);
    }
}
