using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assingnement.Data.Migrations
{
    public partial class R1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineCapacity",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HoursePower",
                table: "Cars");

            migrationBuilder.AddColumn<double>(
                name: "EngineCapacity",
                table: "Models",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "HoursePower",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("1387d29d-c0da-4249-88c6-db358c81cd90"), false, "Audi" },
                    { new Guid("456f0a0d-b207-4de6-8670-5c253f460768"), false, "Mercedes" },
                    { new Guid("54e7f57b-161d-412e-b420-614fea1aca6e"), false, "BMW" },
                    { new Guid("bbdd8b15-d1dc-44cd-ad0d-b738e4b28592"), false, "Volvo" },
                    { new Guid("04eec85c-a70e-426b-b41d-cd74b364f321"), false, "Jaguar" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "BirthDate", "FirstName", "IsDeleted", "LastName" },
                values: new object[,]
                {
                    { new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"), new DateTime(1990, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sevcan", false, "Alkan" },
                    { new Guid("8da05d93-1ae3-4bc4-b3b4-7a6ef582f168"), new DateTime(1985, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", false, "Bulut" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "EngineCapacity", "HoursePower", "IsDeleted", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("5a3a47ad-02ee-4929-bc80-3b2d48e72f57"), new Guid("1387d29d-c0da-4249-88c6-db358c81cd90"), 2.0, 320, false, "A6", 2007 },
                    { new Guid("61821c1d-0f7b-48d1-bc07-031e14512668"), new Guid("456f0a0d-b207-4de6-8670-5c253f460768"), 6.5, 600, false, "E63s AMG", 2021 },
                    { new Guid("9f12071a-865f-4fd3-a501-022a6f9575c7"), new Guid("54e7f57b-161d-412e-b420-614fea1aca6e"), 2.5, 360, false, "540i", 2011 },
                    { new Guid("c102af54-d939-4cca-8de0-cbf6358faf76"), new Guid("bbdd8b15-d1dc-44cd-ad0d-b738e4b28592"), 2.0, 190, false, "V60", 2019 },
                    { new Guid("9633ade9-e481-457f-bec0-f6ca29e551e9"), new Guid("04eec85c-a70e-426b-b41d-cd74b364f321"), 3.0, 400, false, "XF", 2020 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BoughtYear", "Color", "IsDeleted", "ModelId", "OwnerId", "RegistrationNumber" },
                values: new object[] { new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"), 2011, (byte)5, false, new Guid("5a3a47ad-02ee-4929-bc80-3b2d48e72f57"), new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"), "CA 7321 BH" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BoughtYear", "Color", "IsDeleted", "ModelId", "OwnerId", "RegistrationNumber" },
                values: new object[] { new Guid("4b37220a-3ab4-4710-b76b-194376726fd7"), 2017, (byte)4, false, new Guid("61821c1d-0f7b-48d1-bc07-031e14512668"), new Guid("8da05d93-1ae3-4bc4-b3b4-7a6ef582f168"), "A 8256 KX" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("4b37220a-3ab4-4710-b76b-194376726fd7"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("9633ade9-e481-457f-bec0-f6ca29e551e9"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("9f12071a-865f-4fd3-a501-022a6f9575c7"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("c102af54-d939-4cca-8de0-cbf6358faf76"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("04eec85c-a70e-426b-b41d-cd74b364f321"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("54e7f57b-161d-412e-b420-614fea1aca6e"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("bbdd8b15-d1dc-44cd-ad0d-b738e4b28592"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("5a3a47ad-02ee-4929-bc80-3b2d48e72f57"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("61821c1d-0f7b-48d1-bc07-031e14512668"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("8da05d93-1ae3-4bc4-b3b4-7a6ef582f168"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("bc4c27a3-b382-4e76-929b-0ea7c8118d3f"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("1387d29d-c0da-4249-88c6-db358c81cd90"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("456f0a0d-b207-4de6-8670-5c253f460768"));

            migrationBuilder.DropColumn(
                name: "EngineCapacity",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "HoursePower",
                table: "Models");

            migrationBuilder.AddColumn<byte>(
                name: "EngineCapacity",
                table: "Cars",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "HoursePower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
