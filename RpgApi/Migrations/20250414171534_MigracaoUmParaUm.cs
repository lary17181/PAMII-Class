using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.AlterColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 118, 129, 123, 145, 178, 124, 238, 0, 222, 65, 204, 221, 255, 134, 201, 14, 57, 117, 82, 157, 38, 88, 167, 174, 26, 9, 62, 162, 210, 94, 123, 40, 123, 116, 193, 113, 180, 238, 154, 189, 237, 178, 115, 63, 208, 124, 72, 254, 76, 42, 211, 39, 203, 198, 205, 70, 46, 20, 129, 143, 206, 194, 67 }, new byte[] { 43, 2, 76, 158, 204, 210, 214, 139, 214, 225, 19, 153, 33, 24, 19, 71, 84, 35, 235, 236, 23, 238, 16, 5, 18, 140, 102, 53, 187, 185, 77, 144, 37, 95, 189, 18, 95, 235, 143, 235, 201, 28, 197, 79, 177, 67, 74, 207, 90, 64, 51, 117, 246, 128, 37, 237, 117, 179, 0, 63, 245, 65, 144, 62, 89, 45, 190, 132, 99, 8, 3, 205, 135, 28, 231, 62, 7, 11, 161, 71, 113, 55, 124, 255, 28, 144, 70, 2, 122, 82, 186, 123, 83, 252, 72, 156, 133, 75, 20, 71, 37, 219, 247, 221, 106, 214, 184, 213, 225, 158, 93, 233, 89, 30, 140, 79, 97, 16, 90, 21, 142, 220, 29, 115, 219, 39, 23, 104 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.AlterColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 241, 231, 225, 18, 243, 147, 104, 212, 86, 125, 214, 214, 169, 230, 80, 65, 114, 39, 78, 157, 11, 188, 64, 24, 229, 165, 188, 61, 30, 14, 239, 1, 71, 35, 223, 238, 103, 63, 186, 62, 46, 150, 86, 67, 141, 194, 10, 195, 101, 244, 155, 64, 1, 216, 240, 0, 141, 6, 234, 11, 219, 240, 130, 148 }, new byte[] { 163, 154, 225, 203, 53, 81, 242, 37, 20, 117, 111, 202, 239, 172, 208, 119, 248, 124, 19, 117, 157, 123, 95, 11, 59, 228, 186, 9, 230, 242, 96, 71, 202, 79, 94, 35, 174, 200, 159, 101, 98, 61, 25, 255, 205, 185, 40, 217, 187, 226, 255, 111, 112, 17, 106, 193, 123, 103, 18, 169, 247, 234, 249, 9, 176, 42, 16, 210, 191, 137, 202, 28, 52, 253, 233, 124, 45, 162, 66, 33, 2, 25, 177, 178, 245, 252, 148, 194, 146, 143, 68, 113, 81, 133, 70, 141, 124, 40, 147, 26, 137, 9, 101, 180, 140, 31, 47, 242, 14, 117, 209, 123, 220, 243, 120, 157, 146, 65, 160, 32, 247, 76, 210, 56, 51, 168, 136, 157 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true,
                filter: "[PersonagemId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id");
        }
    }
}
