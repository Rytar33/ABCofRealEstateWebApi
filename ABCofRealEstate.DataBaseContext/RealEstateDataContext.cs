using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Data.Models;
using ABCofRealEstate.Data.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            // Locality
            ApplyEnumConverterToString<Apartament, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<House, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Area, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Commertion, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Garage, EnumLocality>(modelBuilder, "Locality");
            // Condition house
            ApplyEnumConverterToString<Apartament, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            ApplyEnumConverterToString<House, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            // Type sales
            ApplyEnumConverterToString<Apartament, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<House, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Commertion, EnumTypeSale>(modelBuilder, "TypeSale");
            // Material house
            ApplyEnumConverterToString<Apartament, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<House, EnumTypeSale>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<Commertion, EnumTypeSale>(modelBuilder, "MaterialHouse");

            base.OnModelCreating(modelBuilder);
        }
        private static void ApplyEnumConverterToString<TEntity, TEnum>(ModelBuilder modelBuilder, string propertyName)
            where TEntity : class
            where TEnum : Enum
        {
            var entity = modelBuilder.Entity<TEntity>();
            var property = entity.Metadata.FindProperty(propertyName);

            if (property != null && property.ClrType == typeof(TEnum))
            {
                property.SetValueConverter(
                    new ValueConverter<TEnum, string>(
                        v => v.ToString(),
                        v => (TEnum)Enum.Parse(typeof(TEnum), v)
                    )
                );
            }
        }
    }
}
