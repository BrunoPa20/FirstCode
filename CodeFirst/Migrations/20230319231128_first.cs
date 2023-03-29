using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odontologos",
                columns: table => new
                {
                    IDOdontologo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OD_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OD_Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OD_Domicilio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OD_Turno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OD_Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OD_Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontologos", x => x.IDOdontologo);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IDPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_DNI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Domicilio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_FechaNac = table.Column<DateTime>(type: "date", nullable: false),
                    P_Ocupacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IDPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    IDTratamiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Procedimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Monto = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.IDTratamiento);
                });

            migrationBuilder.CreateTable(
                name: "agendas",
                columns: table => new
                {
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDOdontologo = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha_Hora_Inicio = table.Column<DateTime>(type: "date", nullable: false),
                    Fecha_Hora_Fin = table.Column<DateTime>(type: "date", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Historials",
                columns: table => new
                {
                    IDHistorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    H_Pregunta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    H_Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    H_Respuesta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    H_Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historials", x => x.IDHistorial);
                    table.ForeignKey(
                        name: "FK_Historials_Pacientes_IDPaciente",
                        column: x => x.IDPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IDPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tutor_Padres",
                columns: table => new
                {
                    ID_Tutor_Padre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TP_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TP_Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TP_Ocupacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor_Padres", x => x.ID_Tutor_Padre);
                    table.ForeignKey(
                        name: "FK_Tutor_Padres_Pacientes_IDPaciente",
                        column: x => x.IDPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IDPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odontogramas",
                columns: table => new
                {
                    IDOdontograma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    O_Posicion = table.Column<int>(type: "int", nullable: false),
                    O_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    O_Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDTratamiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontogramas", x => x.IDOdontograma);
                    table.ForeignKey(
                        name: "FK_Odontogramas_Tratamientos_IDTratamiento",
                        column: x => x.IDTratamiento,
                        principalTable: "Tratamientos",
                        principalColumn: "IDTratamiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago_Tratamientos",
                columns: table => new
                {
                    IDPago_Tramiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PT_Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    PT_Monto = table.Column<int>(type: "int", nullable: false),
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDTratamiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago_Tratamientos", x => x.IDPago_Tramiento);
                    table.ForeignKey(
                        name: "FK_Pago_Tratamientos_Pacientes_IDPaciente",
                        column: x => x.IDPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IDPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_Tratamientos_Tratamientos_IDTratamiento",
                        column: x => x.IDTratamiento,
                        principalTable: "Tratamientos",
                        principalColumn: "IDTratamiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realizas",
                columns: table => new
                {
                    IDPaciente = table.Column<int>(type: "int", nullable: false),
                    IDTratamiento = table.Column<int>(type: "int", nullable: false),
                    R_Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    R_Procedimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realizas", x => new { x.IDPaciente, x.IDTratamiento });
                    table.ForeignKey(
                        name: "FK_Realizas_Pacientes_IDPaciente",
                        column: x => x.IDPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IDPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realizas_Tratamientos_IDTratamiento",
                        column: x => x.IDTratamiento,
                        principalTable: "Tratamientos",
                        principalColumn: "IDTratamiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receta_Medicas",
                columns: table => new
                {
                    IDReceta_Medica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tiempo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDTratamiento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta_Medicas", x => x.IDReceta_Medica);
                    table.ForeignKey(
                        name: "FK_Receta_Medicas_Tratamientos_IDTratamiento",
                        column: x => x.IDTratamiento,
                        principalTable: "Tratamientos",
                        principalColumn: "IDTratamiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agendas_IDOdontologo",
                table: "agendas",
                column: "IDOdontologo");

            migrationBuilder.CreateIndex(
                name: "IX_Historials_IDPaciente",
                table: "Historials",
                column: "IDPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Odontogramas_IDTratamiento",
                table: "Odontogramas",
                column: "IDTratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_Tratamientos_IDPaciente",
                table: "Pago_Tratamientos",
                column: "IDPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_Tratamientos_IDTratamiento",
                table: "Pago_Tratamientos",
                column: "IDTratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Realizas_IDTratamiento",
                table: "Realizas",
                column: "IDTratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Receta_Medicas_IDTratamiento",
                table: "Receta_Medicas",
                column: "IDTratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Tutor_Padres_IDPaciente",
                table: "Tutor_Padres",
                column: "IDPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "Historials");

            migrationBuilder.DropTable(
                name: "Odontogramas");

            migrationBuilder.DropTable(
                name: "Pago_Tratamientos");

            migrationBuilder.DropTable(
                name: "Realizas");

            migrationBuilder.DropTable(
                name: "Receta_Medicas");

            migrationBuilder.DropTable(
                name: "Tutor_Padres");

            migrationBuilder.DropTable(
                name: "Odontologos");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
