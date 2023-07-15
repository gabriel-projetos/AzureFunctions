using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.BookTrack.Migrations
{
    public partial class criatabelaintermediariapararelacionaremprestimoscomusuarioselivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    BookUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoansAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoansStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookUid",
                        column: x => x.BookUid,
                        principalTable: "Books",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserUid",
                        column: x => x.UserUid,
                        principalTable: "Users",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookUid",
                table: "Loans",
                column: "BookUid");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_Uid",
                table: "Loans",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserUid",
                table: "Loans",
                column: "UserUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
