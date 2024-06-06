using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class novocontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aluno_AlunoId",
                table: "Matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Curso_CursoId",
                table: "Matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Disciplina_DisciplinaId",
                table: "Nota");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aluno_AlunoId",
                table: "Matricula",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Curso_CursoId",
                table: "Matricula",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Disciplina_DisciplinaId",
                table: "Nota",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Aluno_AlunoId",
                table: "Matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_Curso_CursoId",
                table: "Matricula");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Disciplina_DisciplinaId",
                table: "Nota");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Aluno_AlunoId",
                table: "Matricula",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_Curso_CursoId",
                table: "Matricula",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Disciplina_DisciplinaId",
                table: "Nota",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
