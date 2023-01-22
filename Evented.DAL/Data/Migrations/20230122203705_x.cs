using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJJyzso/7ZNwDYrC8UKbfcaje5KpqoC/vM5h+Fq8Mi431Z4Qff9EeJYFMhiopJNTlw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG2l6yYCLOXm/Nqh7Y9rALiVVxu1DC6PB8kP0YHWgAmHsOZgSawypAIFZ0u95mswTg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "MYADMIN", "AQAAAAEAACcQAAAAEKLpOTGldzZlv3R4aSs4gxsinKjlD3UKau98oR9GSDR8udHg72LGd/uIGbWPDTwmeA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOJDrwVocde1ztiASEh6UsKnypyyyYhrzxgT4ADu2KFLBthYyhpn0BQS1NU8Z3YaYg==");
        }
    }
}
