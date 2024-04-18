using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCHotel.Models
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<CategoriaProducto> CategoriasProducto { get; set; }

        public DbSet<Apartar> Apartars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId,x.RoleId  });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new {x.UserId,x.LoginProvider,x.Name});
            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(x => x.Id);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasKey(x => x.Id);
        }

    }
}
