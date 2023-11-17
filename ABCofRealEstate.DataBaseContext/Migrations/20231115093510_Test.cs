using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCofRealEstate.DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IDEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IDEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Apartament",
                columns: table => new
                {
                    IdApartament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountRooms = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionHouse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LivingSpace = table.Column<int>(type: "int", nullable: false),
                    TotalArea = table.Column<int>(type: "int", nullable: false),
                    KitchenArea = table.Column<int>(type: "int", nullable: false),
                    CountFloorsHouse = table.Column<int>(type: "int", nullable: false),
                    LocatedFloorApartament = table.Column<int>(type: "int", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    CountBalcony = table.Column<int>(type: "int", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    URLImgs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIDEmployee = table.Column<int>(type: "int", nullable: false),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartament", x => x.IdApartament);
                    table.ForeignKey(
                        name: "FK_Apartament_Employee_EmployeeIDEmployee",
                        column: x => x.EmployeeIDEmployee,
                        principalTable: "Employee",
                        principalColumn: "IDEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLImgs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIDEmployee = table.Column<int>(type: "int", nullable: false),
                    LandArea = table.Column<int>(type: "int", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.IdArea);
                    table.ForeignKey(
                        name: "FK_Area_Employee_EmployeeIDEmployee",
                        column: x => x.EmployeeIDEmployee,
                        principalTable: "Employee",
                        principalColumn: "IDEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commertion",
                columns: table => new
                {
                    IdCommertion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLImgs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIDEmployee = table.Column<int>(type: "int", nullable: false),
                    CountRooms = table.Column<int>(type: "int", nullable: false),
                    LocatedFloorApartament = table.Column<int>(type: "int", nullable: false),
                    CountFloorsHouse = table.Column<int>(type: "int", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    RoomArea = table.Column<int>(type: "int", nullable: false),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commertion", x => x.IdCommertion);
                    table.ForeignKey(
                        name: "FK_Commertion_Employee_EmployeeIDEmployee",
                        column: x => x.EmployeeIDEmployee,
                        principalTable: "Employee",
                        principalColumn: "IDEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    IdGarage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLImgs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIDEmployee = table.Column<int>(type: "int", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.IdGarage);
                    table.ForeignKey(
                        name: "FK_Garage_Employee_EmployeeIDEmployee",
                        column: x => x.EmployeeIDEmployee,
                        principalTable: "Employee",
                        principalColumn: "IDEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    IdHouse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLImgs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: true),
                    EmployeeIDEmployee = table.Column<int>(type: "int", nullable: false),
                    CountRooms = table.Column<int>(type: "int", nullable: false),
                    LocatedFloorApartament = table.Column<int>(type: "int", nullable: false),
                    IsCorner = table.Column<bool>(type: "bit", nullable: false),
                    MaterialHouse = table.Column<int>(type: "int", nullable: true),
                    ConditionHouse = table.Column<int>(type: "int", nullable: true),
                    LivingSpace = table.Column<int>(type: "int", nullable: false),
                    TotalArea = table.Column<int>(type: "int", nullable: false),
                    KitchenArea = table.Column<int>(type: "int", nullable: false),
                    CountFloorsHouse = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false),
                    GardenSot = table.Column<int>(type: "int", nullable: false),
                    TypeSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.IdHouse);
                    table.ForeignKey(
                        name: "FK_House_Employee_EmployeeIDEmployee",
                        column: x => x.EmployeeIDEmployee,
                        principalTable: "Employee",
                        principalColumn: "IDEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartament_EmployeeIDEmployee",
                table: "Apartament",
                column: "EmployeeIDEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Area_EmployeeIDEmployee",
                table: "Area",
                column: "EmployeeIDEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Commertion_EmployeeIDEmployee",
                table: "Commertion",
                column: "EmployeeIDEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Garage_EmployeeIDEmployee",
                table: "Garage",
                column: "EmployeeIDEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_House_EmployeeIDEmployee",
                table: "House",
                column: "EmployeeIDEmployee");
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
                name: "House");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
