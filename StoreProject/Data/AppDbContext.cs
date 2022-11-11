using Microsoft.EntityFrameworkCore;
using StoreProject.Model;

namespace StoreProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
