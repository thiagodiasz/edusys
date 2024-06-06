using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class testenovo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
