using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;

namespace RealEstate.Core.Repositories.Implementations
{
    public class BrandRepository : IGenericRepository<Brand>
    {
        private readonly BrandDbContext _context;

        public BrandRepository(BrandDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _context.brand.ToListAsync();
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.brand.FindAsync(id);
        }

        public async Task AddAsync(Brand brand)
        {
            await _context.brand.AddAsync(brand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Brand brand)
        {
            _context.brand.Update(brand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _context.brand.FindAsync(id);
            if (brand != null)
            {
                _context.brand.Remove(brand);
                await _context.SaveChangesAsync();
            }
        }
    }
}
