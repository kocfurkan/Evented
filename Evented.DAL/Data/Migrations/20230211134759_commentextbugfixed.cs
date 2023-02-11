using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class commentextbugfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comment",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 250);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Text",
                table: "Comment",
                type: "int",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKUvZBvc8/3u7nEFugB8Py39Pboh18Z7/ZdSG8wVWzXvhNGzJ5OazbpmqWS6DR8XEw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBKfIv4NhHw2NY6qEhjz0jNNdG0OMuIEtPEeaMHOSPyNOinqGTiDdz8fbjZBXmDClA==");
        }
    }
}
