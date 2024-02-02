using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Data.Models;
using ABCofRealEstate.Data.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABCofRealEstate.DataBaseContext
{
    public class RealEstateDataContext : DbContext 
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Apartament> Apartament { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Commertion> Commertion { get; set; }
        public DbSet<Garage> Garage { get; set; }
        public DbSet<Hostel> Hostel { get; set; }
        public DbSet<SourceRealEstateObject> SourceRealEstateObject { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Moderator> Moderator { get; set; }
        public RealEstateDataContext() 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=company_abc_real_eatste;Username=postgres;Password=");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Apartament>();
            modelBuilder.Entity<House>();
            modelBuilder.Entity<Area>();
            modelBuilder.Entity<Commertion>();
            modelBuilder.Entity<Garage>();
            modelBuilder.Entity<Hostel>();
            modelBuilder.Entity<SourceRealEstateObject>();
            modelBuilder.Entity<Room>();
            modelBuilder.Entity<Moderator>();
            // Locality
            ApplyEnumConverterToString<Apartament, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<House, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Area, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Commertion, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Garage, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Hostel, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Room, EnumLocality>(modelBuilder, "Locality");
            // Condition house
            ApplyEnumConverterToString<Apartament, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            ApplyEnumConverterToString<House, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            ApplyEnumConverterToString<Hostel, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            ApplyEnumConverterToString<Room, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            // Type sales
            ApplyEnumConverterToString<Apartament, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<House, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Commertion, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Hostel, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Room, EnumTypeSale>(modelBuilder, "TypeSale");
            // Material house
            ApplyEnumConverterToString<Apartament, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<House, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<Commertion, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<Hostel, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<Room, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            // Name object
            ApplyEnumConverterToString<SourceRealEstateObject, EnumObject>(modelBuilder, "NameObject");
            // Job title
            ApplyEnumConverterToString<Employee, EnumJobTitleEmployee>(modelBuilder, "JobTitle");
            // Access level
            ApplyEnumConverterToString<Moderator, EnumAccessLevel>(modelBuilder, "AccessLevel");
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
