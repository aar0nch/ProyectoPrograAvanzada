using Microsoft.EntityFrameworkCore;

namespace MVCHotel.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<CategoriaProducto> CategoriasProducto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
