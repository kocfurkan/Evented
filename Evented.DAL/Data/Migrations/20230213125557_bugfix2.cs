using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class bugfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKOmlxrKIgKU8uuEi2fukxoalCIp1ZumRfhiqU7qw4FqSRDWlTKuPR1IIbBO1AHTsw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAW4tplp8Cfa+5IOYC5y9u+F9QUd76bo+KEjtDAfhPE5TdK1w0tSMOJjM08bYaGEFA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOf6oIcLtZFKxg9EBiiVUfx8F1iDkb7Xc7cxcvc6+DgOuAsMPXtLs5uWq2x4Q8t20w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDRWUHa3Im9Jsv20vvIKthH5uxTn5MVo0kSkQ5/bkNFd9HfuppUNNbTWUFBK04UcaQ==");
        }
    }
}
