using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDisc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Disciplina",
                newName: "materiaId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                newName: "IX_Disciplina_materiaId");

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Disciplina",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Disciplina_materiaId",
                table: "Disciplina",
                column: "materiaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Disciplina_materiaId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Disciplina");

            migrationBuilder.RenameColumn(
                name: "materiaId",
                table: "Disciplina",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplina_materiaId",
                table: "Disciplina",
                newName: "IX_Disciplina_ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
