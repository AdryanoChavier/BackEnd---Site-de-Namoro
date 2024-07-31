using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizadaUsuarioModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConhecidoComo",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataDeNascimento",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Interesses",
                table: "Usuario",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introducao",
                table: "Usuario",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PrimeiroLogin",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProcurandoPor",
                table: "Usuario",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    AppUsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Usuario_AppUsuarioId",
                        column: x => x.AppUsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_AppUsuarioId",
                table: "Fotos",
                column: "AppUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ConhecidoComo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Interesses",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Introducao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PrimeiroLogin",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ProcurandoPor",
                table: "Usuario");
        }
    }
}
