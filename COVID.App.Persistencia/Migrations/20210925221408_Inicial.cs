using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COVID.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_sede = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidad_salones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aforo = table.Column<int>(type: "int", nullable: false),
                    numerosalon = table.Column<int>(type: "int", nullable: false),
                    sedeid = table.Column<int>(type: "int", nullable: true),
                    unidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Salones_Sedes_sedeid",
                        column: x => x.sedeid,
                        principalTable: "Sedes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    facultad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semestre = table.Column<int>(type: "int", nullable: true),
                    Claseid = table.Column<int>(type: "int", nullable: true),
                    turno = table.Column<int>(type: "int", nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    asignatura = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profesorid = table.Column<int>(type: "int", nullable: true),
                    cantidad_inscritos = table.Column<int>(type: "int", nullable: false),
                    salonid = table.Column<int>(type: "int", nullable: true),
                    Dia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuracionClase = table.Column<int>(type: "int", nullable: false),
                    hora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.id);
                    table.ForeignKey(
                        name: "FK_Clases_Personas_profesorid",
                        column: x => x.profesorid,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clases_Salones_salonid",
                        column: x => x.salonid,
                        principalTable: "Salones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaClinicas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sintoma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    personaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinicas", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistoriaClinicas_Personas_personaid",
                        column: x => x.personaid,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clases_profesorid",
                table: "Clases",
                column: "profesorid");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_salonid",
                table: "Clases",
                column: "salonid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinicas_personaid",
                table: "HistoriaClinicas",
                column: "personaid");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Claseid",
                table: "Personas",
                column: "Claseid");

            migrationBuilder.CreateIndex(
                name: "IX_Salones_sedeid",
                table: "Salones",
                column: "sedeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Clases_Claseid",
                table: "Personas",
                column: "Claseid",
                principalTable: "Clases",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Personas_profesorid",
                table: "Clases");

            migrationBuilder.DropTable(
                name: "HistoriaClinicas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DropTable(
                name: "Sedes");
        }
    }
}
