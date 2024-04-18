using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHotel.Migrations
{
    /// <inheritdoc />
    public partial class apartar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartars",
                columns: table => new
                {
                    ApartarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    fechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartars", x => x.ApartarId);
                    table.ForeignKey(
                        name: "FK_Apartars_Productos_idProducto",
                        column: x => x.idProducto,
                        principalTable: "Productos",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartars_idProducto",
                table: "Apartars",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Apartars_UserId",
                table: "Apartars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartars");
        }
    }
}
