using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreProject.Migrations
{
    public partial class GenericRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Produtos",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produtos",
                newName: "IdProduto");
        }
    }
}
