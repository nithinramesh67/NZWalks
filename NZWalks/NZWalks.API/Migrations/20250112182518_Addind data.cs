using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Addinddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4300c759-736a-403f-8aaf-8d606378ffd2"), "Easy" },
                    { new Guid("4bd8fc8b-7982-4bcb-a3ea-4708967f8b06"), "Hard" },
                    { new Guid("af9199b8-5a57-4138-ba86-c3204bb75bcc"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0ac86219-a84c-4fce-b0c1-db0b14e3c9ac"), "NAP", "Napier-Hastings", "https://upload.wikimedia.org/wikipedia/commons/4/4b/Napier_Hastings.jpg" },
                    { new Guid("35ac7d7d-0978-4495-93b8-469a2d240e37"), "CHR", "Christchurch", "https://upload.wikimedia.org/wikipedia/commons/8/8e/Christchurch_Cathedral.jpg" },
                    { new Guid("51a9170f-eb58-45d7-913f-377c980825d2"), "DUN", "Dunedin", "https://upload.wikimedia.org/wikipedia/commons/5/5c/Dunedin_City.jpg" },
                    { new Guid("5c61e9de-85f4-48aa-b9ea-be0603f91f8d"), "WEL", "Wellington", "https://upload.wikimedia.org/wikipedia/commons/3/3e/Wellington_City_Skyline.jpg" },
                    { new Guid("901035d4-dd1d-4fa3-a0fc-9db3c41713b5"), "HAM", "Hamilton", "https://upload.wikimedia.org/wikipedia/commons/4/4f/Hamilton_Gardens.jpg" },
                    { new Guid("a4d3a610-b010-459e-87ed-84c65d35d15a"), "AUK", "Auckland", "https://upload.wikimedia.org/wikipedia/commons/3/3b/Auckland_City_Skyline.jpg" },
                    { new Guid("b2bac570-237b-473c-9edf-f40533ac4dba"), "PAL", "Palmerston North", "https://upload.wikimedia.org/wikipedia/commons/7/7e/Palmerston_North_City.jpg" },
                    { new Guid("cd1ee686-1d2b-43b1-9ded-bdaa13f9692a"), "TAU", "Tauranga", "https://upload.wikimedia.org/wikipedia/commons/2/2c/Tauranga_Bay.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4300c759-736a-403f-8aaf-8d606378ffd2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4bd8fc8b-7982-4bcb-a3ea-4708967f8b06"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("af9199b8-5a57-4138-ba86-c3204bb75bcc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0ac86219-a84c-4fce-b0c1-db0b14e3c9ac"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("35ac7d7d-0978-4495-93b8-469a2d240e37"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("51a9170f-eb58-45d7-913f-377c980825d2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5c61e9de-85f4-48aa-b9ea-be0603f91f8d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("901035d4-dd1d-4fa3-a0fc-9db3c41713b5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4d3a610-b010-459e-87ed-84c65d35d15a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b2bac570-237b-473c-9edf-f40533ac4dba"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cd1ee686-1d2b-43b1-9ded-bdaa13f9692a"));
        }
    }
}
