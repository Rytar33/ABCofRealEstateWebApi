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
                name: "moderator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    AccessLevel = table.Column<string>(type: "text", nullable: false),
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
                    NameObject = table.Column<string>(type: "text", nullable: false),
                    IdSource = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_source_real_estate_object", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "apartament",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    NumberApartament = table.Column<short>(type: "smallint", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    LivingSpace = table.Column<double>(type: "double precision", nullable: false),
                    TotalArea = table.Column<double>(type: "double precision", nullable: false),
                    KitchenArea = table.Column<double>(type: "double precision", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    LandArea = table.Column<int>(type: "integer", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "commertion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    RoomArea = table.Column<double>(type: "double precision", nullable: false),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commertion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImgId = table.Column<Guid>(type: "uuid", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    JobTitle = table.Column<int>(type: "integer", nullable: false),
                    NumberPhone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "garage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_garage_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hostel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    LivingSpace = table.Column<double>(type: "double precision", nullable: false),
                    TotalArea = table.Column<double>(type: "double precision", nullable: false),
                    KitchenArea = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    NumberApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hostel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hostel_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "house",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    LivingSpace = table.Column<double>(type: "double precision", nullable: false),
                    TotalArea = table.Column<double>(type: "double precision", nullable: false),
                    KitchenArea = table.Column<double>(type: "double precision", nullable: false),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    GardenSot = table.Column<double>(type: "double precision", nullable: false),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_house", x => x.Id);
                    table.ForeignKey(
                        name: "FK_house_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    District = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    DateTimePublished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActual = table.Column<bool>(type: "boolean", nullable: false),
                    CountRooms = table.Column<short>(type: "smallint", nullable: false),
                    LocatedFloorApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountFloorsHouse = table.Column<short>(type: "smallint", nullable: false),
                    IsCorner = table.Column<bool>(type: "boolean", nullable: false),
                    MaterialHouse = table.Column<int>(type: "integer", nullable: true),
                    TypeSale = table.Column<string>(type: "text", nullable: false),
                    NumberProperty = table.Column<string>(type: "text", nullable: false),
                    LivingSpace = table.Column<double>(type: "double precision", nullable: false),
                    TotalArea = table.Column<double>(type: "double precision", nullable: false),
                    KitchenArea = table.Column<double>(type: "double precision", nullable: false),
                    ConditionHouse = table.Column<int>(type: "integer", nullable: true),
                    NumberApartament = table.Column<short>(type: "smallint", nullable: false),
                    CountBalcony = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_room_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    DataImg = table.Column<byte[]>(type: "bytea", nullable: false),
                    ApartamentId = table.Column<Guid>(type: "uuid", nullable: true),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: true),
                    CommertionId = table.Column<Guid>(type: "uuid", nullable: true),
                    GarageId = table.Column<Guid>(type: "uuid", nullable: true),
                    HostelId = table.Column<Guid>(type: "uuid", nullable: true),
                    HouseId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_image_apartament_ApartamentId",
                        column: x => x.ApartamentId,
                        principalTable: "apartament",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_image_area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_image_commertion_CommertionId",
                        column: x => x.CommertionId,
                        principalTable: "commertion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_image_garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "garage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_image_hostel_HostelId",
                        column: x => x.HostelId,
                        principalTable: "hostel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_image_house_HouseId",
                        column: x => x.HouseId,
                        principalTable: "house",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_image_room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_apartament_EmployeeId",
                table: "apartament",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_area_EmployeeId",
                table: "area",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_commertion_EmployeeId",
                table: "commertion",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_ImgId",
                table: "employee",
                column: "ImgId");

            migrationBuilder.CreateIndex(
                name: "IX_garage_EmployeeId",
                table: "garage",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_hostel_EmployeeId",
                table: "hostel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_house_EmployeeId",
                table: "house",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_image_ApartamentId",
                table: "image",
                column: "ApartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_image_AreaId",
                table: "image",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_image_CommertionId",
                table: "image",
                column: "CommertionId");

            migrationBuilder.CreateIndex(
                name: "IX_image_GarageId",
                table: "image",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_image_HostelId",
                table: "image",
                column: "HostelId");

            migrationBuilder.CreateIndex(
                name: "IX_image_HouseId",
                table: "image",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_image_RoomId",
                table: "image",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_room_EmployeeId",
                table: "room",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_apartament_employee_EmployeeId",
                table: "apartament",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_area_employee_EmployeeId",
                table: "area",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_commertion_employee_EmployeeId",
                table: "commertion",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_image_ImgId",
                table: "employee",
                column: "ImgId",
                principalTable: "image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apartament_employee_EmployeeId",
                table: "apartament");

            migrationBuilder.DropForeignKey(
                name: "FK_area_employee_EmployeeId",
                table: "area");

            migrationBuilder.DropForeignKey(
                name: "FK_commertion_employee_EmployeeId",
                table: "commertion");

            migrationBuilder.DropForeignKey(
                name: "FK_garage_employee_EmployeeId",
                table: "garage");

            migrationBuilder.DropForeignKey(
                name: "FK_hostel_employee_EmployeeId",
                table: "hostel");

            migrationBuilder.DropForeignKey(
                name: "FK_house_employee_EmployeeId",
                table: "house");

            migrationBuilder.DropForeignKey(
                name: "FK_room_employee_EmployeeId",
                table: "room");

            migrationBuilder.DropTable(
                name: "moderator");

            migrationBuilder.DropTable(
                name: "source_real_estate_object");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "apartament");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "commertion");

            migrationBuilder.DropTable(
                name: "garage");

            migrationBuilder.DropTable(
                name: "hostel");

            migrationBuilder.DropTable(
                name: "house");

            migrationBuilder.DropTable(
                name: "room");
        }
    }
}
