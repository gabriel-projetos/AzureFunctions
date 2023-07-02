using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.BookTrack.Migrations
{
    public partial class alteranomedatabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizationModel_Users_UserUid",
                table: "AuthorizationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorizationModel",
                table: "AuthorizationModel");

            migrationBuilder.RenameTable(
                name: "AuthorizationModel",
                newName: "Authorizations");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorizationModel_UserUid",
                table: "Authorizations",
                newName: "IX_Authorizations_UserUid");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorizationModel_Uid",
                table: "Authorizations",
                newName: "IX_Authorizations_Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_Authorizations_Users_UserUid",
                table: "Authorizations",
                column: "UserUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authorizations_Users_UserUid",
                table: "Authorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.RenameTable(
                name: "Authorizations",
                newName: "AuthorizationModel");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_UserUid",
                table: "AuthorizationModel",
                newName: "IX_AuthorizationModel_UserUid");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_Uid",
                table: "AuthorizationModel",
                newName: "IX_AuthorizationModel_Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorizationModel",
                table: "AuthorizationModel",
                column: "Uid");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorizationModel_Users_UserUid",
                table: "AuthorizationModel",
                column: "UserUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
