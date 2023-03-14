using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class _2daMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "tipo_Documentos",
                newName: "TipoDocumento");

            migrationBuilder.AddColumn<int>(
                name: "Id_Tipo_documento",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Id_Tipo_documento",
                table: "Ventas",
                column: "Id_Tipo_documento");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_tipo_Documentos_Id_Tipo_documento",
                table: "Ventas",
                column: "Id_Tipo_documento",
                principalTable: "tipo_Documentos",
                principalColumn: "Id_Tipo_documento",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_tipo_Documentos_Id_Tipo_documento",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_Id_Tipo_documento",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Id_Tipo_documento",
                table: "Ventas");

            migrationBuilder.RenameColumn(
                name: "TipoDocumento",
                table: "tipo_Documentos",
                newName: "Documento");
        }
    }
}
