using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articulos",
                columns: table => new
                {
                    ArticuloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articulos", x => x.ArticuloID);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tipo_Documentos",
                columns: table => new
                {
                    Id_Tipo_documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_Documentos", x => x.Id_Tipo_documento);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    num_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_cliente = table.Column<int>(type: "int", nullable: false),
                    ArticuloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.num_venta);
                    table.ForeignKey(
                        name: "FK_Ventas_articulos_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "articulos",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_clientes_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "clientes",
                        principalColumn: "Id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ArticuloID",
                table: "Ventas",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Id_cliente",
                table: "Ventas",
                column: "Id_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tipo_Documentos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "articulos");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
