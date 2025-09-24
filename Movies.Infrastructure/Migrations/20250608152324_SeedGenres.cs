using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("03b6508c-e52a-48e7-a9f4-f7dee2b311f1"), "Family" },
                    { new Guid("10d1b4cf-732e-47f4-a548-60bbeee9aeb4"), "Documentary" },
                    { new Guid("4c4ccd31-16b4-4922-b0ed-f5481bd813f7"), "Sci-Fi" },
                    { new Guid("4d05fb9f-a205-4b16-a1c5-fd0e198652f5"), "Musical" },
                    { new Guid("6742e068-7729-465a-befe-6d3e76efa9fc"), "Comedy" },
                    { new Guid("78dd3d3a-361d-4e7c-91ac-df0b6cbdbbd7"), "Adventure" },
                    { new Guid("80a1db55-0d24-4eb5-a5d5-27361bcb6039"), "Thriller" },
                    { new Guid("8a1705a0-c107-42b3-a4b6-ff7af8971d04"), "Horror" },
                    { new Guid("9ceed180-37b2-4de7-be74-baf0675100ad"), "War" },
                    { new Guid("9fc1f505-aa85-49c2-ae4e-f2616b47f294"), "Romance" },
                    { new Guid("a3056e90-e607-4d80-b79a-be4a303fb750"), "History" },
                    { new Guid("a4254d6b-7e05-4834-ba64-1f0aab18baca"), "Western" },
                    { new Guid("c0b896ec-9d08-4e37-8319-7408d946635e"), "Mystery" },
                    { new Guid("c249776f-64a6-44c5-9780-24bd5222094e"), "Sport" },
                    { new Guid("c2f54e31-f790-4192-85ad-21ce154b2731"), "Action" },
                    { new Guid("d72c8397-de4c-4a48-bc5d-02fd87d72f6e"), "Animation" },
                    { new Guid("e1452955-8ad1-422b-b3ac-04a7eb2c8595"), "Fantasy" },
                    { new Guid("e913cfee-92a8-4586-9e49-9cd7af8d71b6"), "Crime" },
                    { new Guid("edc4e41b-39ee-4162-a650-faa8022938a1"), "Biography" },
                    { new Guid("f86cb42e-3a99-4238-be25-72fec73afd18"), "Drama" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("03b6508c-e52a-48e7-a9f4-f7dee2b311f1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("10d1b4cf-732e-47f4-a548-60bbeee9aeb4"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4c4ccd31-16b4-4922-b0ed-f5481bd813f7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4d05fb9f-a205-4b16-a1c5-fd0e198652f5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6742e068-7729-465a-befe-6d3e76efa9fc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("78dd3d3a-361d-4e7c-91ac-df0b6cbdbbd7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("80a1db55-0d24-4eb5-a5d5-27361bcb6039"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8a1705a0-c107-42b3-a4b6-ff7af8971d04"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9ceed180-37b2-4de7-be74-baf0675100ad"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9fc1f505-aa85-49c2-ae4e-f2616b47f294"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a3056e90-e607-4d80-b79a-be4a303fb750"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a4254d6b-7e05-4834-ba64-1f0aab18baca"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c0b896ec-9d08-4e37-8319-7408d946635e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c249776f-64a6-44c5-9780-24bd5222094e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c2f54e31-f790-4192-85ad-21ce154b2731"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d72c8397-de4c-4a48-bc5d-02fd87d72f6e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e1452955-8ad1-422b-b3ac-04a7eb2c8595"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e913cfee-92a8-4586-9e49-9cd7af8d71b6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("edc4e41b-39ee-4162-a650-faa8022938a1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f86cb42e-3a99-4238-be25-72fec73afd18"));
        }
    }
}
