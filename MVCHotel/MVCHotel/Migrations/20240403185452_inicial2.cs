using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHotel.Migrations
{
    /// <inheritdoc />
    public partial class inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasProducto",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasProducto", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProducto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcionProducto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    precioProducto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Productos_CategoriasProducto_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "CategoriasProducto",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idCategoria",
                table: "Productos",
                column: "idCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "CategoriasProducto");
        }
    }
}
