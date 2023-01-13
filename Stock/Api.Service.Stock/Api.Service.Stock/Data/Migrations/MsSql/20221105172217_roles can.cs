using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Data.Migrations.MsSql
{
    public partial class rolescan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RolesCanRead",
                table: "TipoPagamentos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RolesCanRead",
                table: "TipoPagamentos");
        }
    }
}
