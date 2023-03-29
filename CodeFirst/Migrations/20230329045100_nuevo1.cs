using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class nuevo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "agendas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agendas",
                columns: table => new
                {
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDOdontologo = table.Column<int>(type: "int", nullable: false),
                    Fecha_Hora_Fin = table.Column<DateTime>(type: "date", nullable: false),
                    Fecha_Hora_Inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendas", x => new { x.IDPaciente, x.IDOdontologo });
                    table.ForeignKey(
                        name: "FK_agendas_Odontologos_IDOdontologo",
                        column: x => x.IDOdontologo,
                        principalTable: "Odontologos",
                        principalColumn: "IDOdontologo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_agendas_Pacientes_IDPaciente",
                        column: x => x.IDPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IDPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agendas_IDOdontologo",
                table: "agendas",
                column: "IDOdontologo");
        }
    }
}
