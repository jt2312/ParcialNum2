using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alfajor",
                columns: table => new
                {
                    AlfajorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreAlfajor = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<int>(type: "INTEGER", nullable: false),
                    Calorias = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alfajor", x => x.AlfajorID);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    MarcaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreMarca = table.Column<string>(type: "TEXT", nullable: false),
                    PaisMarca = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.MarcaID);
                });

            migrationBuilder.CreateTable(
                name: "MarcaAlfajores",
                columns: table => new
                {
                    AlfajorsAlfajorID = table.Column<int>(type: "INTEGER", nullable: false),
                    MarcasMarcaID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaAlfajores", x => new { x.AlfajorsAlfajorID, x.MarcasMarcaID });
                    table.ForeignKey(
                        name: "FK_MarcaAlfajores_Alfajor_AlfajorsAlfajorID",
                        column: x => x.AlfajorsAlfajorID,
                        principalTable: "Alfajor",
                        principalColumn: "AlfajorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcaAlfajores_Marca_MarcasMarcaID",
                        column: x => x.MarcasMarcaID,
                        principalTable: "Marca",
                        principalColumn: "MarcaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarcaAlfajores_MarcasMarcaID",
                table: "MarcaAlfajores",
                column: "MarcasMarcaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaAlfajores");

            migrationBuilder.DropTable(
                name: "Alfajor");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
