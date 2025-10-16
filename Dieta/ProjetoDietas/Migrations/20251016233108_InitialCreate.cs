using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDietas.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    EnergiaKcal = table.Column<double>(type: "REAL", nullable: false),
                    Proteina = table.Column<double>(type: "REAL", nullable: false),
                    Lipideos = table.Column<double>(type: "REAL", nullable: false),
                    Carboidratos = table.Column<double>(type: "REAL", nullable: false),
                    FibraAlimentar = table.Column<double>(type: "REAL", nullable: false),
                    Sodio = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentos");
        }
    }
}
