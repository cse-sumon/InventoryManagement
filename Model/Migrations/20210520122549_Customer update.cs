using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Customerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Customers",
                newName: "CustomerType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerType",
                table: "Customers",
                newName: "type");
        }
    }
}
