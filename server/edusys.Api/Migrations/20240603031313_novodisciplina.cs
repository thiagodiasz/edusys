using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class novodisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId");
        }
    }
}
