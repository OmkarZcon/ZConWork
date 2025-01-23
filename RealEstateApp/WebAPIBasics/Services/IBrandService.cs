using System.Collections.Generic;

namespace RealEstate.Api.Services
{
    public interface IBrandService
    {

        List<string> GetAllBrands();
        string CreateBrand(string brandName);
        string UpdateBrand(int id, string brandName);
        bool DeleteBrand(int id);
    }
}
