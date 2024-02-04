using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Koronba.Core.Migrations
{
    /// <inheritdoc />
    public partial class SeedTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00e0107c-c103-4989-abe4-c638666bf661"), "Wtf" },
                    { new Guid("185eb500-d530-49d9-b7e2-27da68420fcd"), "Lol" },
                    { new Guid("48030715-6457-4e8b-a03d-a0bd23e2fb6f"), "Cool" },
                    { new Guid("697c4da3-a1da-4007-9c20-a83677141ff5"), "Game" },
                    { new Guid("8b8ea90b-e979-4ebb-897e-6f50ad9e27cd"), "Loop" },
                    { new Guid("a64e3efd-b3d8-4fdc-8f5f-8ca745dd9b96"), "Misc" },
                    { new Guid("bfccb5fa-f397-43f5-9b97-e462ee8114d4"), "Classic" },
                    { new Guid("d3368962-80ec-4ad8-9974-7bacfcc08237"), "Aww" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tags_Name",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("00e0107c-c103-4989-abe4-c638666bf661"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("185eb500-d530-49d9-b7e2-27da68420fcd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("48030715-6457-4e8b-a03d-a0bd23e2fb6f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("697c4da3-a1da-4007-9c20-a83677141ff5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8b8ea90b-e979-4ebb-897e-6f50ad9e27cd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("a64e3efd-b3d8-4fdc-8f5f-8ca745dd9b96"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("bfccb5fa-f397-43f5-9b97-e462ee8114d4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("d3368962-80ec-4ad8-9974-7bacfcc08237"));
        }
    }
}
