using RegistroPedidos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace RegistroPedidos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=DATA\Pedidos.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Productos>().HasData(new Productos( 1, "Saco Arroz 15Lb", 362.95f, 20));
            modelBuilder.Entity<Productos>().HasData(new Productos( 2, "Pan Francés", 36.95f, 60));
            modelBuilder.Entity<Productos>().HasData(new Productos( 3, "Funda Pan Sobao", 50.00f, 80));
            modelBuilder.Entity<Productos>().HasData(new Productos( 4, "Jugo de Naranja", 124.95f, 50));
            modelBuilder.Entity<Productos>().HasData(new Productos( 5, "Jugo de Manzana", 124.95f, 50));
            modelBuilder.Entity<Productos>().HasData(new Productos( 6, "Pierna de Salami", 314.95f, 100));
            modelBuilder.Entity<Productos>().HasData(new Productos( 7, "Leche Evaporada Grande", 80.00f, 70));
            modelBuilder.Entity<Productos>().HasData(new Productos( 8, "Leche Evaporada Pequeña", 59.95f, 60));
            modelBuilder.Entity<Productos>().HasData(new Productos( 9, "Funda Pan Sobao", 50.00f, 80));
            modelBuilder.Entity<Productos>().HasData(new Productos( 10, "Jamon Caserío", 206.95f, 30));
            modelBuilder.Entity<Productos>().HasData(new Productos( 11, "Frasco de Mayonesa", 99.95f, 40));
            modelBuilder.Entity<Productos>().HasData(new Productos( 12, "Ketchup", 115.95f, 40));

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores(1, "Induveca"));
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores(2, "Carnation"));
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores(3, "Rica"));
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores(4, "Pimco"));
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores(5, "Baldom"));
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores(6, "Yoma"));
        }
    }
}