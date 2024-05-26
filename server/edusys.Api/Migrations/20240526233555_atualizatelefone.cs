using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace edusys.Api.Migrations
{
    /// <inheritdoc />
    public partial class atualizatelefone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Professor");

            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Professor",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DDD = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_TelefoneId",
                table: "Professor",
                column: "TelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Telefone_TelefoneId",
                table: "Professor",
                column: "TelefoneId",
                principalTable: "Telefone",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Telefone_TelefoneId",
                table: "Professor");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Professor_TelefoneId",
                table: "Professor");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Professor");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Professor",
                type: "text",
                nullable: true);
        }
    }
}
