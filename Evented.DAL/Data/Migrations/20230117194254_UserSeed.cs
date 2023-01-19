using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "User", "USER" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birth", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "x", new DateTime(2023, 1, 17, 22, 42, 53, 798, DateTimeKind.Local).AddTicks(4351), "295770ce-3f4b-4677-b0af-8d200fb60b8f", new DateTime(2023, 1, 17, 22, 42, 53, 798, DateTimeKind.Local).AddTicks(4359), null, true, "Furkan", "X", "Koc", false, null, null, "MYADMIN", "AQAAAAEAACcQAAAAEB1Kx+3marakJSiik2ftmeXYGjAyz7JdOYBMGnSkE+rmq0CTpNRz3JrkhmWp49iXew==", null, true, "a43230f0-c9b2-406b-ab50-cd0905055fd1", false, "myadmin" },
                    { "b74ddd14-6340-4840-95c2-db12554843e6", 0, "x", new DateTime(2023, 1, 17, 22, 42, 53, 805, DateTimeKind.Local).AddTicks(1909), "295770ce-3f4b-4677-b0af-8d200fb60b87", new DateTime(2023, 1, 17, 22, 42, 53, 805, DateTimeKind.Local).AddTicks(1911), null, true, "Furkan", "X", "Koc", false, null, null, "MYUSER", "AQAAAAEAACcQAAAAEENuY+lUOFhdwYOzqovdFhTq5ok9iNdrsoUef1TuGlH2IN7NF4yUwLSIKefcrIbxDg==", null, true, "a43230f0-c9b2-406b-ab50-cd0905055fd9", false, "myuser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554843e6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db12554843e6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6");
        }
    }
}
