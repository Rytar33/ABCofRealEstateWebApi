using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCofRealEstate.DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class AddAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    IdImg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataImg = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.IdImg);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdImg = table.Column<int>(type: "int", nullable: false),
                    ImageIdImg = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<int>(type: "int", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employee_Image_ImageIdImg",
                        column: x => x.ImageIdImg,
                        principalTable: "Image",
                        principalColumn: "IdImg");
                });

            migrationBuilder.CreateTable(
                name: "Apartament",
                columns: table => new
                {
                    IdApartament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberApartament = table.Column<short>(type: "smallint", nullable: false),
                    NumberProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionHouse = table.Column<int>(type: "int", nullable: true),
                    LivingSpace = table.Column<double>(type: "float", nullable: false),
                    TotalArea = table.Column<double>(type: "float", nullable: false),
                    KitchenArea = table.Column<double>(type: "float", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    IdsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: true),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartament", x => x.IdApartament);
                    table.ForeignKey(
                        name: "FK_Apartament_Employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: true),
                    LandArea = table.Column<int>(type: "int", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.IdArea);
                    table.ForeignKey(
                        name: "FK_Area_Employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateTable(
                name: "Commertion",
                columns: table => new
                {
                    IdCommertion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    RoomArea = table.Column<double>(type: "float", nullable: false),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false),
                    NumberProperty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commertion", x => x.IdCommertion);
                    table.ForeignKey(
                        name: "FK_Commertion_Employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    IdGarage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: true),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.IdGarage);
                    table.ForeignKey(
                        name: "FK_Garage_Employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateTable(
                name: "Hostel",
                columns: table => new
                {
                    IdHostel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivingSpace = table.Column<double>(type: "float", nullable: false),
                    TotalArea = table.Column<double>(type: "float", nullable: false),
                    KitchenArea = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: true),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionHouse = table.Column<int>(type: "int", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false),
                    NumberProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostel", x => x.IdHostel);
                    table.ForeignKey(
                        name: "FK_Hostel_Employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    IdHouse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    ConditionHouse = table.Column<int>(type: "int", nullable: true),
                    LivingSpace = table.Column<double>(type: "float", nullable: false),
                    TotalArea = table.Column<double>(type: "float", nullable: false),
                    KitchenArea = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    GardenSot = table.Column<double>(type: "float", nullable: false),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false),
                    NumberProperty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.IdHouse);
                    table.ForeignKey(
                        name: "FK_House_Employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    IdRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdsImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: true),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActual = table.Column<bool>(type: "bit", nullable: false),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberProperty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivingSpace = table.Column<double>(type: "float", nullable: false),
                    TotalArea = table.Column<double>(type: "float", nullable: false),
                    KitchenArea = table.Column<double>(type: "float", nullable: false),
                    ConditionHouse = table.Column<int>(type: "int", nullable: true),
                    NumberApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.IdRoom);
                    table.ForeignKey(
                        name: "FK_Room_Employee_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartament_EmployeeIdEmployee",
                table: "Apartament",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Area_EmployeeIdEmployee",
                table: "Area",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Commertion_EmployeeIdEmployee",
                table: "Commertion",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ImageIdImg",
                table: "Employee",
                column: "ImageIdImg");

            migrationBuilder.CreateIndex(
                name: "IX_Garage_EmployeeIdEmployee",
                table: "Garage",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Hostel_EmployeeIdEmployee",
                table: "Hostel",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_House_EmployeeIdEmployee",
                table: "House",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Room_EmployeeIdEmployee",
                table: "Room",
                column: "EmployeeIdEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartament");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Commertion");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "Hostel");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
