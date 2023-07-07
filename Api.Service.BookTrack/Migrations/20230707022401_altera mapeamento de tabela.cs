using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.BookTrack.Migrations
{
    public partial class alteramapeamentodetabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Users_UserUid",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_UserUid",
                table: "Authorizations");

            migrationBuilder.AddColumn<Guid>(
                name: "DbUserUid",
                table: "Authorizations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_DbUserUid",
                table: "Authorizations",
                column: "DbUserUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Users_DbUserUid",
                table: "Authorizations",
                column: "DbUserUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Users_DbUserUid",
                table: "Authorizations");

            migrationBuilder.DropIndex(
                name: "IX_Authorizations_DbUserUid",
                table: "Authorizations");

            migrationBuilder.DropColumn(
                name: "DbUserUid",
                table: "Authorizations");

            migrationBuilder.CreateIndex(
                name: "IX_Authorizations_UserUid",
                table: "Authorizations",
                column: "UserUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Users_UserUid",
                table: "Authorizations",
                column: "UserUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
