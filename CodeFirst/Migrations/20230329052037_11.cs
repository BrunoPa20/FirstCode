using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class _11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agendas",
                columns: table => new
                {
                    IDAgenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha_Hora_Inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Fecha_Hora_Fin = table.Column<DateTime>(type: "date", nullable: false),
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDOdontologo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendas", x => x.IDAgenda);
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

            migrationBuilder.CreateIndex(
                name: "IX_agendas_IDPaciente",
                table: "agendas",
                column: "IDPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "agendas");
        }
    }
}
