using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuarioid = table.Column<int>(name: "usuario_id", type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    usuarionome = table.Column<string>(name: "usuario_nome", type: "TEXT", nullable: false),
                    usuariosobrenome = table.Column<string>(name: "usuario_sobrenome", type: "TEXT", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuarioid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
