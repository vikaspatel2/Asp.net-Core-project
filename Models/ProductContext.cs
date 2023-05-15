using Microsoft.EntityFrameworkCore;

namespace VIKAS.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            Products = Set<Product>();
        }

        public DbSet<Product> Products { get; set; }
    }
}
