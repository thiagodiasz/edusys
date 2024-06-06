using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class testeno : Migration
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

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "integer", nullable: false),
                    DisciplinasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => new { x.CursoId, x.DisciplinasId });
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplina_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinasId",
                table: "CursoDisciplina",
                column: "DisciplinasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoDisciplina");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
