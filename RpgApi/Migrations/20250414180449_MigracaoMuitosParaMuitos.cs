using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADE_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADE",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adromecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 120, 176, 176, 31, 234, 32, 253, 107, 54, 99, 158, 50, 93, 94, 0, 49, 124, 79, 251, 83, 232, 115, 185, 46, 54, 50, 92, 112, 60, 189, 202, 114, 186, 23, 139, 136, 107, 11, 37, 171, 51, 150, 137, 1, 123, 173, 192, 133, 118, 222, 79, 43, 170, 160, 24, 211, 19, 186, 139, 202, 117, 251, 163 }, new byte[] { 76, 77, 150, 144, 116, 80, 116, 61, 108, 204, 100, 229, 29, 240, 9, 149, 247, 27, 185, 68, 218, 113, 225, 47, 24, 14, 55, 160, 140, 33, 238, 112, 33, 210, 33, 230, 96, 10, 56, 225, 174, 31, 58, 190, 210, 70, 43, 89, 227, 22, 96, 3, 160, 199, 69, 235, 74, 109, 29, 254, 220, 124, 100, 115, 176, 208, 126, 76, 147, 72, 69, 121, 51, 149, 170, 102, 155, 162, 57, 255, 186, 238, 80, 62, 96, 206, 116, 21, 20, 243, 207, 190, 249, 240, 189, 226, 152, 38, 113, 29, 227, 146, 26, 178, 20, 250, 196, 226, 134, 51, 111, 246, 96, 98, 216, 230, 111, 240, 45, 0, 38, 162, 11, 177, 144, 28, 17, 52 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADE");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 118, 129, 123, 145, 178, 124, 238, 0, 222, 65, 204, 221, 255, 134, 201, 14, 57, 117, 82, 157, 38, 88, 167, 174, 26, 9, 62, 162, 210, 94, 123, 40, 123, 116, 193, 113, 180, 238, 154, 189, 237, 178, 115, 63, 208, 124, 72, 254, 76, 42, 211, 39, 203, 198, 205, 70, 46, 20, 129, 143, 206, 194, 67 }, new byte[] { 43, 2, 76, 158, 204, 210, 214, 139, 214, 225, 19, 153, 33, 24, 19, 71, 84, 35, 235, 236, 23, 238, 16, 5, 18, 140, 102, 53, 187, 185, 77, 144, 37, 95, 189, 18, 95, 235, 143, 235, 201, 28, 197, 79, 177, 67, 74, 207, 90, 64, 51, 117, 246, 128, 37, 237, 117, 179, 0, 63, 245, 65, 144, 62, 89, 45, 190, 132, 99, 8, 3, 205, 135, 28, 231, 62, 7, 11, 161, 71, 113, 55, 124, 255, 28, 144, 70, 2, 122, 82, 186, 123, 83, 252, 72, 156, 133, 75, 20, 71, 37, 219, 247, 221, 106, 214, 184, 213, 225, 158, 93, 233, 89, 30, 140, 79, 97, 16, 90, 21, 142, 220, 29, 115, 219, 39, 23, 104 } });
        }
    }
}
