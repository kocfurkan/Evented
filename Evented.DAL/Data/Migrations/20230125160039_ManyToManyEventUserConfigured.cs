using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evented.Web.Data.Migrations
{
    public partial class ManyToManyEventUserConfigured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvent", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserEvent_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEWQR3uS67RJy2x+3uHZDAeL83OmlQiqna+pLTxTRGLlXoX7uSborQf46T8ZZDs+6Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "USER@USER.COM", "AQAAAAEAACcQAAAAEJ9Gu22uxl5CE6z0cyeX8lG8h0xFgHXOw5DFuLhrfds6xMzr0lqDQeM6LA0vQXt3ng==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_UserId",
                table: "UserEvent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventJoinedId = table.Column<int>(type: "int", nullable: false),
                    UserJoinedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.EventJoinedId, x.UserJoinedId });
                    table.ForeignKey(
                        name: "FK_EventUser_AspNetUsers_UserJoinedId",
                        column: x => x.UserJoinedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Event_EventJoinedId",
                        column: x => x.EventJoinedId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "MYUSER", "AQAAAAEAACcQAAAAEOl1L1PtbEd0fXypBD6BlpSG1m+Cx8eXU0t/de2EQdYo50gBsMJo03X9hhI5rX2TMA==" });

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UserJoinedId",
                table: "EventUser",
                column: "UserJoinedId");
        }
    }
}
