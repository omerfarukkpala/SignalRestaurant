using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuTableID",
                table: "Baskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuTables",
                columns: table => new
                {
                    MenuTableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTables", x => x.MenuTableID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_MenuTableID",
                table: "Baskets",
                column: "MenuTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableID",
                table: "Baskets",
                column: "MenuTableID",
                principalTable: "MenuTables",
                principalColumn: "MenuTableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableID",
                table: "Baskets");

            migrationBuilder.DropTable(
                name: "MenuTables");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_MenuTableID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "MenuTableID",
                table: "Baskets");
        }
    }
}
