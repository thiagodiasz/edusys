using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Disciplina",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professor_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_EnderecoId",
                table: "Professor",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Disciplina");
        }
    }
}
