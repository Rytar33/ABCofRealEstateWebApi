using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Data.Models;

namespace ABCofRealEstate.DataBaseContext
{
    public class RealEstateDataContext : DbContext 
    {
        DbSet<Employee> Employee { get; set; }
        DbSet<Apartament> Apartament { get; set; }
        DbSet<House> House { get; set; }
        DbSet<Area> Area { get; set; }
        DbSet<Commertion> Commertion { get; set; }
        DbSet<Garage> Garage { get; set; }
        private readonly object _connection = 
            new 
            {
                server = "localhost",
                database = "ABCofRealEstate",
                trustServerSertificate = true,
                trustedConnection = true,
            };
        public RealEstateDataContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost;Database=ABCofRealEstate;TrustServerCertificate=True;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Apartament>();
            modelBuilder.Entity<House>();
            modelBuilder.Entity<Area>();
            modelBuilder.Entity<Commertion>();
            modelBuilder.Entity<Garage>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
