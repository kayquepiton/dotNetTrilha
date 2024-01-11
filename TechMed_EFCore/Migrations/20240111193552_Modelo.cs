using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechMed_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Modelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_MedicoId",
                table: "Atendimentos");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_PacienteId",
                table: "Atendimentos",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Pacientes_PacienteId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_PacienteId",
                table: "Atendimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Pacientes_MedicoId",
                table: "Atendimentos",
                column: "MedicoId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
