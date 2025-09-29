using Inventario.Modelos;
using Microsoft.EntityFrameworkCore;
namespace Inventario.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ProveedorCategoria> ProveedorCategorias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId)
                .IsRequired();
            modelBuilder.Entity<Proveedor>()
                .HasMany(p => p.Productos)
                .WithOne(p => p.Proveedor)
                .HasForeignKey(p => p.ProveedorId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<ProveedorCategoria>()
                .HasKey(pc => new { pc.ProveedorId, pc.CategoriaId });

            modelBuilder.Entity<ProveedorCategoria>()
                .HasOne(pc => pc.Proveedor)
                .WithMany(p => p.ProveedorCategorias)
                .HasForeignKey(pc => pc.ProveedorId);

            modelBuilder.Entity<ProveedorCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany(c => c.ProveedorCategorias)
                .HasForeignKey(pc => pc.CategoriaId);
        }
    }
}
