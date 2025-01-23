using System.Collections.Generic;

namespace RealEstate.Api.Services
{
    public class BrandService : IBrandService
    {
        private static List<string> _brands = new List<string>();

        public List<string> GetAllBrands()
        {
            return _brands;
        }

        public string CreateBrand(string brandName)
        {
            _brands.Add(brandName);
            return brandName;
        }

        public string UpdateBrand(int id, string brandName)
        {
            if (id < 0 || id >= _brands.Count)
                return null;

            _brands[id] = brandName;
            return brandName;
        }

        public bool DeleteBrand(int id)
        {
            if (id < 0 || id >= _brands.Count)
                return false;

            _brands.RemoveAt(id);
            return true;
        }
    }
}
