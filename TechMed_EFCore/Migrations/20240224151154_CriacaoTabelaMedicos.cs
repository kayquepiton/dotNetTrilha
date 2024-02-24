using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechMedEFCore.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaMedicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_MedicoId",
                table: "Atendimentos",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Medicos_MedicoId",
                table: "Atendimentos",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Medicos_MedicoId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_MedicoId",
                table: "Atendimentos");
        }
    }
}
