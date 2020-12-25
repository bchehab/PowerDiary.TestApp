using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerDiary.TestApp.EntityFrameworkCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatEventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatEventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: true),
                    ChatEventTypeId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatEvents_ChatEventTypes_ChatEventTypeId",
                        column: x => x.ChatEventTypeId,
                        principalTable: "ChatEventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatEvents_Users_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatEvents_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ChatEventTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Enter the room", "enter-the-room" },
                    { 2, "Leave the room", "leave-the-room" },
                    { 3, "Comment", "comment" },
                    { 4, "High-five another user", "high-five-another-user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "IsActive", "ModifiedDate", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 24, 23, 37, 39, 199, DateTimeKind.Utc).AddTicks(5735), true, null, "Bob" },
                    { 2, new DateTime(2020, 12, 24, 23, 37, 39, 199, DateTimeKind.Utc).AddTicks(6678), true, null, "Kate" },
                    { 3, new DateTime(2020, 12, 24, 23, 37, 39, 199, DateTimeKind.Utc).AddTicks(6682), true, null, "Alice" },
                    { 4, new DateTime(2020, 12, 24, 23, 37, 39, 199, DateTimeKind.Utc).AddTicks(6683), true, null, "John" }
                });

            migrationBuilder.InsertData(
                table: "ChatEvents",
                columns: new[] { "Id", "ChatEventTypeId", "CreatedDate", "IsActive", "Message", "ModifiedDate", "User1Id", "User2Id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 12, 24, 17, 0, 0, 0, DateTimeKind.Utc), true, null, null, 1, null },
                    { 3, 3, new DateTime(2020, 12, 24, 17, 15, 0, 0, DateTimeKind.Utc), true, "Hey, Kate - high five?", null, 1, null },
                    { 5, 2, new DateTime(2020, 12, 24, 17, 18, 0, 0, DateTimeKind.Utc), true, null, null, 1, null },
                    { 2, 1, new DateTime(2020, 12, 24, 17, 5, 0, 0, DateTimeKind.Utc), true, null, null, 2, null },
                    { 4, 4, new DateTime(2020, 12, 24, 17, 17, 0, 0, DateTimeKind.Utc), true, null, null, 2, 1 },
                    { 6, 3, new DateTime(2020, 12, 24, 17, 20, 0, 0, DateTimeKind.Utc), true, "Oh, typical", null, 2, null },
                    { 7, 2, new DateTime(2020, 12, 24, 17, 21, 0, 0, DateTimeKind.Utc), true, null, null, 2, null },
                    { 8, 1, new DateTime(2020, 12, 24, 18, 0, 0, 0, DateTimeKind.Utc), true, null, null, 2, null },
                    { 11, 4, new DateTime(2020, 12, 24, 18, 15, 0, 0, DateTimeKind.Utc), true, null, null, 1, 2 },
                    { 9, 1, new DateTime(2020, 12, 24, 18, 5, 0, 0, DateTimeKind.Utc), true, null, null, 3, null },
                    { 12, 4, new DateTime(2020, 12, 24, 18, 20, 0, 0, DateTimeKind.Utc), true, null, null, 2, 3 },
                    { 14, 4, new DateTime(2020, 12, 24, 18, 24, 0, 0, DateTimeKind.Utc), false, null, null, 3, 1 },
                    { 10, 1, new DateTime(2020, 12, 24, 18, 10, 0, 0, DateTimeKind.Utc), true, null, null, 4, null },
                    { 13, 4, new DateTime(2020, 12, 24, 18, 25, 0, 0, DateTimeKind.Utc), true, null, null, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatEvents_ChatEventTypeId",
                table: "ChatEvents",
                column: "ChatEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatEvents_CreatedDate",
                table: "ChatEvents",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ChatEvents_Message",
                table: "ChatEvents",
                column: "Message");

            migrationBuilder.CreateIndex(
                name: "IX_ChatEvents_User1Id",
                table: "ChatEvents",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChatEvents_User2Id",
                table: "ChatEvents",
                column: "User2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatEvents");

            migrationBuilder.DropTable(
                name: "ChatEventTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
