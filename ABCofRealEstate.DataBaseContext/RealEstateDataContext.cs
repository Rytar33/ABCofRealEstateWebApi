using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Data.Models;
using ABCofRealEstate.Data.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABCofRealEstate.DataBaseContext
{
    public class RealEstateDataContext : DbContext 
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Comertion> Comertion { get; set; }
        public DbSet<Garage> Garage { get; set; }
        public DbSet<Hostel> Hostel { get; set; }
        public DbSet<SourceRealEstateObject> SourceRealEstateObject { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Moderator> Moderator { get; set; }
        public RealEstateDataContext() 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=dpg-cosh37nsc6pc73e7766g-a;Port=5432;Database=company_abc_real_estate;" +
                "Username=company_abc_of_real_estate_user;Password=qfv6iAGZkaDZvdY1dWKuNziauGWHg2oj");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Apartment>();
            modelBuilder.Entity<House>();
            modelBuilder.Entity<Area>();
            modelBuilder.Entity<Comertion>();
            modelBuilder.Entity<Garage>();
            modelBuilder.Entity<Hostel>();
            modelBuilder.Entity<SourceRealEstateObject>();
            modelBuilder.Entity<Room>();
            modelBuilder.Entity<Moderator>()
                .HasData(
                    new Moderator(
                        "Oleg", 
                        "oleg.olegov@gmail.com",
                        "DAAAD6E5604E8E17BD9F108D91E26AFE6281DAC8FDA0091040A7A6D7BD9B43B5")
                        { Id = Guid.NewGuid(), IsSuperModerator = true });
            // Locality
            ApplyEnumConverterToString<Apartment, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<House, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Area, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Comertion, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Garage, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Hostel, EnumLocality>(modelBuilder, "Locality");
            ApplyEnumConverterToString<Room, EnumLocality>(modelBuilder, "Locality");
            // Condition house
            ApplyEnumConverterToString<Apartment, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            ApplyEnumConverterToString<House, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            ApplyEnumConverterToString<Hostel, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            ApplyEnumConverterToString<Room, EnumConditionHouse>(modelBuilder, "ConditionHouse");
            // Type sales
            ApplyEnumConverterToString<Apartment, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Area, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Garage, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<House, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Comertion, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Hostel, EnumTypeSale>(modelBuilder, "TypeSale");
            ApplyEnumConverterToString<Room, EnumTypeSale>(modelBuilder, "TypeSale");
            // Material house
            ApplyEnumConverterToString<Apartment, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<House, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<Comertion, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<Hostel, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            ApplyEnumConverterToString<Room, EnumMaterialHouse>(modelBuilder, "MaterialHouse");
            // Name object
            ApplyEnumConverterToString<SourceRealEstateObject, EnumObject>(modelBuilder, "NameObject");
            // Job title
            ApplyEnumConverterToString<Employee, EnumJobTitleEmployee>(modelBuilder, "JobTitle");
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
