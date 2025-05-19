using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Deudores_DeudoresDeudorId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_DeudoresDeudorId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "DeudorId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "DeudoresDeudorId",
                table: "Prestamos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeudorId",
                table: "Prestamos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeudoresDeudorId",
                table: "Prestamos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_DeudoresDeudorId",
                table: "Prestamos",
                column: "DeudoresDeudorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Deudores_DeudoresDeudorId",
                table: "Prestamos",
                column: "DeudoresDeudorId",
                principalTable: "Deudores",
                principalColumn: "DeudorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
