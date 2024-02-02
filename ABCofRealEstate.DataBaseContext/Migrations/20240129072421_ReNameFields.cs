using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCofRealEstate.DataBaseContext.Migrations
{
    /// <inheritdoc />
    public partial class ReNameFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_image_ImgId",
                table: "employee");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropIndex(
                name: "IX_employee_ImgId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "IdSource",
                table: "source_real_estate_object");

            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "employee");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceRealEstateObjectId",
                table: "room",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SourceRealEstateObjectId",
                table: "house",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SourceRealEstateObjectId",
                table: "hostel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SourceRealEstateObjectId",
                table: "garage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TypeSale",
                table: "garage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "employee",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceRealEstateObjectId",
                table: "commertion",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SourceRealEstateObjectId",
                table: "area",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TypeSale",
                table: "area",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SourceRealEstateObjectId",
                table: "apartament",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_room_SourceRealEstateObjectId",
                table: "room",
                column: "SourceRealEstateObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_house_SourceRealEstateObjectId",
                table: "house",
                column: "SourceRealEstateObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_hostel_SourceRealEstateObjectId",
                table: "hostel",
                column: "SourceRealEstateObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_garage_SourceRealEstateObjectId",
                table: "garage",
                column: "SourceRealEstateObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_commertion_SourceRealEstateObjectId",
                table: "commertion",
                column: "SourceRealEstateObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_area_SourceRealEstateObjectId",
                table: "area",
                column: "SourceRealEstateObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_apartament_SourceRealEstateObjectId",
                table: "apartament",
                column: "SourceRealEstateObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_apartament_source_real_estate_object_SourceRealEstateObject~",
                table: "apartament",
                column: "SourceRealEstateObjectId",
                principalTable: "source_real_estate_object",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_area_source_real_estate_object_SourceRealEstateObjectId",
                table: "area",
                column: "SourceRealEstateObjectId",
                principalTable: "source_real_estate_object",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_commertion_source_real_estate_object_SourceRealEstateObject~",
                table: "commertion",
                column: "SourceRealEstateObjectId",
                principalTable: "source_real_estate_object",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_garage_source_real_estate_object_SourceRealEstateObjectId",
                table: "garage",
                column: "SourceRealEstateObjectId",
                principalTable: "source_real_estate_object",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hostel_source_real_estate_object_SourceRealEstateObjectId",
                table: "hostel",
                column: "SourceRealEstateObjectId",
                principalTable: "source_real_estate_object",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_house_source_real_estate_object_SourceRealEstateObjectId",
                table: "house",
                column: "SourceRealEstateObjectId",
                principalTable: "source_real_estate_object",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_room_source_real_estate_object_SourceRealEstateObjectId",
                table: "room",
                column: "SourceRealEstateObjectId",
                principalTable: "source_real_estate_object",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_apartament_source_real_estate_object_SourceRealEstateObject~",
                table: "apartament");

            migrationBuilder.DropForeignKey(
                name: "FK_area_source_real_estate_object_SourceRealEstateObjectId",
                table: "area");

            migrationBuilder.DropForeignKey(
                name: "FK_commertion_source_real_estate_object_SourceRealEstateObject~",
                table: "commertion");

            migrationBuilder.DropForeignKey(
                name: "FK_garage_source_real_estate_object_SourceRealEstateObjectId",
                table: "garage");

            migrationBuilder.DropForeignKey(
                name: "FK_hostel_source_real_estate_object_SourceRealEstateObjectId",
                table: "hostel");

            migrationBuilder.DropForeignKey(
                name: "FK_house_source_real_estate_object_SourceRealEstateObjectId",
                table: "house");

            migrationBuilder.DropForeignKey(
                name: "FK_room_source_real_estate_object_SourceRealEstateObjectId",
                table: "room");

            migrationBuilder.DropIndex(
                name: "IX_room_SourceRealEstateObjectId",
                table: "room");

            migrationBuilder.DropIndex(
                name: "IX_house_SourceRealEstateObjectId",
                table: "house");

            migrationBuilder.DropIndex(
                name: "IX_hostel_SourceRealEstateObjectId",
                table: "hostel");

            migrationBuilder.DropIndex(
                name: "IX_garage_SourceRealEstateObjectId",
                table: "garage");

            migrationBuilder.DropIndex(
                name: "IX_commertion_SourceRealEstateObjectId",
                table: "commertion");

            migrationBuilder.DropIndex(
                name: "IX_area_SourceRealEstateObjectId",
                table: "area");

            migrationBuilder.DropIndex(
                name: "IX_apartament_SourceRealEstateObjectId",
                table: "apartament");

            migrationBuilder.DropColumn(
                name: "SourceRealEstateObjectId",
                table: "room");

            migrationBuilder.DropColumn(
                name: "SourceRealEstateObjectId",
                table: "house");

            migrationBuilder.DropColumn(
                name: "SourceRealEstateObjectId",
                table: "hostel");

            migrationBuilder.DropColumn(
                name: "SourceRealEstateObjectId",
                table: "garage");

            migrationBuilder.DropColumn(
                name: "TypeSale",
                table: "garage");

            migrationBuilder.DropColumn(
                name: "SourceRealEstateObjectId",
                table: "commertion");

            migrationBuilder.DropColumn(
                name: "SourceRealEstateObjectId",
                table: "area");

            migrationBuilder.DropColumn(
                name: "TypeSale",
                table: "area");

            migrationBuilder.DropColumn(
                name: "SourceRealEstateObjectId",
                table: "apartament");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSource",
                table: "source_real_estate_object",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "JobTitle",
                table: "employee",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "ImgId",
                table: "employee",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApartamentId = table.Column<Guid>(type: "uuid", nullable: true),
                    AreaId = table.Column<Guid>(type: "uuid", nullable: true),
                    CommertionId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataImg = table.Column<byte[]>(type: "bytea", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    GarageId = table.Column<Guid>(type: "uuid", nullable: true),
                    HostelId = table.Column<Guid>(type: "uuid", nullable: true),
                    HouseId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false)
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
                name: "IX_employee_ImgId",
                table: "employee",
                column: "ImgId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_employee_image_ImgId",
                table: "employee",
                column: "ImgId",
                principalTable: "image",
                principalColumn: "Id");
        }
    }
}
