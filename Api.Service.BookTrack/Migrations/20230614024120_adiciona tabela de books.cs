using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.BookTrack.Migrations
{
    public partial class adicionatabeladebooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Authors = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPages = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acquisition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    CopiesRented = table.Column<int>(type: "int", nullable: false),
                    BookCover = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Uid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Uid",
                table: "Books",
                column: "Uid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
