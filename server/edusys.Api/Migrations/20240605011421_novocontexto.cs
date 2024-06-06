using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class novocontexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Estado_EstadoId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Professor_EnderecoId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_EnderecoId",
                table: "Professor",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_UF",
                table: "Estado",
                column: "UF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Estado_EstadoId",
                table: "Endereco",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Estado_EstadoId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Professor_EnderecoId",
                table: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Estado_UF",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_EnderecoId",
                table: "Professor",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_EnderecoId",
                table: "Aluno",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Estado_EstadoId",
                table: "Endereco",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
