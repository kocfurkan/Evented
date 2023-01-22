using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class EmailAde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "admin@admin.com", "AQAAAAEAACcQAAAAEJUEsLEOuHu9Bre7PZIx1nNh0b2XiTSobdJJ3mAvNcTcuAWSsGzLNj/CsdQ6F5r52Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "user@user.com", "AQAAAAEAACcQAAAAELgtEukVc+g1Z4RnKnkMonNL6NR0hizuG+nI0p322HXGoGaBYVZbh4C4iFN0Yn2Epg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { null, "AQAAAAEAACcQAAAAED1Wd/uT4y4UQkdHXYD6u/JGJktymozoyrfx5LvU8UFymwjQFbf+Ji8QvV2dyRt+pg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { null, "AQAAAAEAACcQAAAAEI0RPwAShaDAZnZlcc9jMfFQSYSlWS3periiPly6Ej1KTTThvvT8XfM9rvoVdURP4w==" });
        }
    }
}
