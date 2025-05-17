using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrestamosId",
                table: "Prestamos",
                newName: "PrestamoId");

            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "Prestamos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "Monto",
                table: "Prestamos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Deudores_DeudoresDeudorId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "Deudores");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_DeudoresDeudorId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "DeudorId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "DeudoresDeudorId",
                table: "Prestamos");

            migrationBuilder.DropColumn(
                name: "Monto",
                table: "Prestamos");

            migrationBuilder.RenameColumn(
                name: "PrestamoId",
                table: "Prestamos",
                newName: "PrestamosId");
        }
    }
}
