using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_CursoId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Disciplina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Disciplina",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_CursoId",
                table: "Disciplina",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Curso_CursoId",
                table: "Disciplina",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id");
        }
    }
}
