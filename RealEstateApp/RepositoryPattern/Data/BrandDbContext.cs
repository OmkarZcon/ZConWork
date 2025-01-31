using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.Data
{
    public class BrandDbContext  : DbContext
    {
        public BrandDbContext()
        {
        }

        public BrandDbContext(DbContextOptions<BrandDbContext> options) : base(options)
        {
        }
        public DbSet<Brand> brand { get; set; }
    }
}
