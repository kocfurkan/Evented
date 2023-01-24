using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class JoineeNumbAddedToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "joineeNumber",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHYTwx5EJEn3c8fZK2cvMF9lPuya+FyeRAiH+PRWDbl6UZh5o9l2NAdmdiE4/KseCQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOl1L1PtbEd0fXypBD6BlpSG1m+Cx8eXU0t/de2EQdYo50gBsMJo03X9hhI5rX2TMA==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "joineeNumber",
                table: "Event");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJJyzso/7ZNwDYrC8UKbfcaje5KpqoC/vM5h+Fq8Mi431Z4Qff9EeJYFMhiopJNTlw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG2l6yYCLOXm/Nqh7Y9rALiVVxu1DC6PB8kP0YHWgAmHsOZgSawypAIFZ0u95mswTg==");
        }
    }
}
