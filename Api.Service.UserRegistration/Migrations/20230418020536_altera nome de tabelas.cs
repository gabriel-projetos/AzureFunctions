using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.UserRegistration.Migrations
{
    public partial class alteranomedetabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizationModel_Users_UserUid",
                table: "AuthorizationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoModel_Users_UserUid",
                table: "UserInfoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfoModel",
                table: "UserInfoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorizationModel",
                table: "AuthorizationModel");

            migrationBuilder.RenameTable(
                name: "UserInfoModel",
                newName: "UserInfos");

            migrationBuilder.RenameTable(
                name: "AuthorizationModel",
                newName: "Authorizations");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfoModel_UserUid",
                table: "UserInfos",
                newName: "IX_UserInfos_UserUid");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfoModel_Uid",
                table: "UserInfos",
                newName: "IX_UserInfos_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorizationModel_UserUid",
                table: "Authorizations",
                newName: "IX_Authorizations_UserUid");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorizationModel_Uid",
                table: "Authorizations",
                newName: "IX_Authorizations_Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos",
                column: "Uid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Users_UserUid",
                table: "UserInfos",
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

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_Users_UserUid",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.RenameTable(
                name: "UserInfos",
                newName: "UserInfoModel");

            migrationBuilder.RenameTable(
                name: "Authorizations",
                newName: "AuthorizationModel");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_UserUid",
                table: "UserInfoModel",
                newName: "IX_UserInfoModel_UserUid");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfos_Uid",
                table: "UserInfoModel",
                newName: "IX_UserInfoModel_Uid");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_UserUid",
                table: "AuthorizationModel",
                newName: "IX_AuthorizationModel_UserUid");

            migrationBuilder.RenameIndex(
                name: "IX_Authorizations_Uid",
                table: "AuthorizationModel",
                newName: "IX_AuthorizationModel_Uid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfoModel",
                table: "UserInfoModel",
                column: "Uid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfoModel_Users_UserUid",
                table: "UserInfoModel",
                column: "UserUid",
                principalTable: "Users",
                principalColumn: "Uid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
