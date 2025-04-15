using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: true, defaultValue: "jogador"),
                    Email = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, 1 });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", null, -23.520024100000001, -46.596497999999997, new byte[] { 81, 82, 176, 216, 129, 122, 0, 137, 112, 120, 93, 87, 50, 217, 40, 239, 25, 67, 125, 177, 160, 121, 107, 163, 178, 234, 109, 78, 48, 10, 77, 181, 95, 83, 92, 115, 154, 170, 159, 148, 230, 177, 43, 1, 157, 206, 30, 238, 70, 112, 234, 80, 41, 211, 32, 103, 180, 60, 64, 113, 220, 108, 77, 34 }, new byte[] { 13, 52, 96, 11, 63, 49, 143, 22, 100, 209, 140, 139, 69, 136, 126, 190, 207, 2, 3, 135, 70, 68, 169, 195, 0, 193, 183, 64, 187, 29, 212, 255, 17, 118, 249, 50, 96, 183, 44, 55, 93, 188, 183, 68, 99, 231, 237, 110, 205, 134, 109, 215, 69, 187, 152, 101, 34, 220, 140, 151, 139, 90, 238, 248, 191, 80, 80, 201, 232, 52, 76, 94, 122, 116, 73, 145, 11, 34, 118, 108, 235, 189, 76, 109, 73, 194, 107, 181, 165, 108, 147, 209, 52, 220, 9, 146, 235, 178, 143, 243, 110, 41, 96, 50, 215, 7, 92, 188, 120, 38, 85, 100, 116, 66, 52, 91, 105, 206, 94, 27, 182, 239, 168, 81, 82, 155, 99, 227 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_UsuarioId",
                table: "TB_PERSONAGENS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioId",
                table: "TB_PERSONAGENS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PERSONAGENS_TB_USUARIOS_UsuarioId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_PERSONAGENS_UsuarioId",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_PERSONAGENS");
        }
    }
}
