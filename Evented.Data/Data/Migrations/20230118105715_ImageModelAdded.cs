using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class ImageModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageGalleries_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageGalleries_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageGalleryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_ImageGalleries_ImageGalleryId",
                        column: x => x.ImageGalleryId,
                        principalTable: "ImageGalleries",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Birth", "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEHSoB1Ko3BslHSVsYnY93+TfDmVrGeLvHxugI2zfdPjP2QtAVS4On87S/w2poNSgKQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "Birth", "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEFtpsygNlDTB4/AjMfri7U3k/Z+jxHBG/6OA1qBsf1FzO/KjyBLraYuCy6N8pop6eA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ImageGalleries_CompanyId",
                table: "ImageGalleries",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImageGalleries_EventId",
                table: "ImageGalleries",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageGalleryId",
                table: "Images",
                column: "ImageGalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ImageGalleries");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Birth", "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 42, 53, 798, DateTimeKind.Local).AddTicks(4351), new DateTime(2023, 1, 17, 22, 42, 53, 798, DateTimeKind.Local).AddTicks(4359), "AQAAAAEAACcQAAAAEB1Kx+3marakJSiik2ftmeXYGjAyz7JdOYBMGnSkE+rmq0CTpNRz3JrkhmWp49iXew==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "Birth", "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 42, 53, 805, DateTimeKind.Local).AddTicks(1909), new DateTime(2023, 1, 17, 22, 42, 53, 805, DateTimeKind.Local).AddTicks(1911), "AQAAAAEAACcQAAAAEENuY+lUOFhdwYOzqovdFhTq5ok9iNdrsoUef1TuGlH2IN7NF4yUwLSIKefcrIbxDg==" });
        }
    }
}
