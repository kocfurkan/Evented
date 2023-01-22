using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "PasswordHash", "UserName" },
                values: new object[] { "AQAAAAEAACcQAAAAEKLpOTGldzZlv3R4aSs4gxsinKjlD3UKau98oR9GSDR8udHg72LGd/uIGbWPDTwmeA==", "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "PasswordHash", "UserName" },
                values: new object[] { "AQAAAAEAACcQAAAAEOJDrwVocde1ztiASEh6UsKnypyyyYhrzxgT4ADu2KFLBthYyhpn0BQS1NU8Z3YaYg==", "user@user.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "PasswordHash", "UserName" },
                values: new object[] { "AQAAAAEAACcQAAAAEJUEsLEOuHu9Bre7PZIx1nNh0b2XiTSobdJJ3mAvNcTcuAWSsGzLNj/CsdQ6F5r52Q==", "myadmin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "PasswordHash", "UserName" },
                values: new object[] { "AQAAAAEAACcQAAAAELgtEukVc+g1Z4RnKnkMonNL6NR0hizuG+nI0p322HXGoGaBYVZbh4C4iFN0Yn2Epg==", "myuser" });
        }
    }
}
