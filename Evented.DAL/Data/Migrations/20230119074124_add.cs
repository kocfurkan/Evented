using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEK9IGvTu/eRCC6QVBuALUTCmYLhmqm+fYuBQxxwDaw1Hi2taJOAboboc2J7+lbJmSw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG6VKXKVSmtahgi0d9pcH3E0Kj9mTAnDCOrOv6GUdtDIvJNfLvD5GxUsRpxWPgHCxw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHSoB1Ko3BslHSVsYnY93+TfDmVrGeLvHxugI2zfdPjP2QtAVS4On87S/w2poNSgKQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFtpsygNlDTB4/AjMfri7U3k/Z+jxHBG/6OA1qBsf1FzO/KjyBLraYuCy6N8pop6eA==");
        }
    }
}
