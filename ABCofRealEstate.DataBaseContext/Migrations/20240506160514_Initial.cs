using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCofRealEstate.DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false),
                    NumberPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "moderator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsSuperModerator = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moderator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "source_real_estate_object",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameObject = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_source_real_estate_object", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "apartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    NumberApartment = table.Column<short>(type: "smallint", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    LivingSpace = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: false),
                    KitchenArea = table.Column<decimal>(type: "numeric", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartment = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    SourceRealEstateObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apartment_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_apartment_source_real_estate_object_SourceRealEstateObjectId",
                        column: x => x.SourceRealEstateObjectId,
                        principalTable: "source_real_estate_object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    SourceRealEstateObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    LandArea = table.Column<int>(type: "integer", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_area_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_area_source_real_estate_object_SourceRealEstateObjectId",
                        column: x => x.SourceRealEstateObjectId,
                        principalTable: "source_real_estate_object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comertion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    SourceRealEstateObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartment = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    RoomArea = table.Column<decimal>(type: "numeric", nullable: false),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comertion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comertion_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comertion_source_real_estate_object_SourceRealEstateObjectId",
                        column: x => x.SourceRealEstateObjectId,
                        principalTable: "source_real_estate_object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "garage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    SourceRealEstateObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    GarageCapacity = table.Column<short>(type: "smallint", nullable: false),
                    HaveBasement = table.Column<bool>(type: "boolean", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_garage_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_garage_source_real_estate_object_SourceRealEstateObjectId",
                        column: x => x.SourceRealEstateObjectId,
                        principalTable: "source_real_estate_object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hostel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    SourceRealEstateObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    LivingSpace = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: false),
                    KitchenArea = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartment = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    NumberApartment = table.Column<short>(type: "smallint", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hostel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hostel_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_hostel_source_real_estate_object_SourceRealEstateObjectId",
                        column: x => x.SourceRealEstateObjectId,
                        principalTable: "source_real_estate_object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "house",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    SourceRealEstateObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartment = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    LivingSpace = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: false),
                    KitchenArea = table.Column<decimal>(type: "numeric", nullable: false),
                    Area = table.Column<decimal>(type: "numeric", nullable: false),
                    GardenSot = table.Column<decimal>(type: "numeric", nullable: false),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_house", x => x.Id);
                    table.ForeignKey(
                        name: "FK_house_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_house_source_real_estate_object_SourceRealEstateObjectId",
                        column: x => x.SourceRealEstateObjectId,
                        principalTable: "source_real_estate_object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    SourceRealEstateObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartment = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    LivingSpace = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalArea = table.Column<decimal>(type: "numeric", nullable: false),
                    KitchenArea = table.Column<decimal>(type: "numeric", nullable: false),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    NumberApartment = table.Column<short>(type: "smallint", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_room_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_room_source_real_estate_object_SourceRealEstateObjectId",
                        column: x => x.SourceRealEstateObjectId,
                        principalTable: "source_real_estate_object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "moderator",
                columns: new[] { "Id", "Email", "IsSuperModerator", "Name", "Password" },
                values: new object[] { new Guid("80ec665e-5300-468a-b395-7be86ee70008"), "oleg.olegov@gmail.com", true, "Oleg", "DAAAD6E5604E8E17BD9F108D91E26AFE6281DAC8FDA0091040A7A6D7BD9B43B5" });

            migrationBuilder.CreateIndex(
                name: "IX_apartment_EmployeeId",
                table: "apartment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_apartment_SourceRealEstateObjectId",
                table: "apartment",
                column: "SourceRealEstateObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_area_EmployeeId",
                table: "area",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_area_SourceRealEstateObjectId",
                table: "area",
                column: "SourceRealEstateObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comertion_EmployeeId",
                table: "comertion",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_comertion_SourceRealEstateObjectId",
                table: "comertion",
                column: "SourceRealEstateObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_garage_EmployeeId",
                table: "garage",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_garage_SourceRealEstateObjectId",
                table: "garage",
                column: "SourceRealEstateObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hostel_EmployeeId",
                table: "hostel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_hostel_SourceRealEstateObjectId",
                table: "hostel",
                column: "SourceRealEstateObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_house_EmployeeId",
                table: "house",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_house_SourceRealEstateObjectId",
                table: "house",
                column: "SourceRealEstateObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_room_EmployeeId",
                table: "room",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_room_SourceRealEstateObjectId",
                table: "room",
                column: "SourceRealEstateObjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apartment");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "comertion");

            migrationBuilder.DropTable(
                name: "garage");

            migrationBuilder.DropTable(
                name: "hostel");

            migrationBuilder.DropTable(
                name: "house");

            migrationBuilder.DropTable(
                name: "moderator");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "source_real_estate_object");
        }
    }
}
