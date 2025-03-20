using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class New_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ArCondicionado",
                table: "carros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Cambio",
                table: "carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Capacidade",
                table: "carros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Combustivel",
                table: "carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaManutencao",
                table: "carros",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "carros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoDiaria",
                table: "carros",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quilometragem",
                table: "carros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "carros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "locacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiasAlugados = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locacao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locacao");

            migrationBuilder.DropColumn(
                name: "ArCondicionado",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Cambio",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Capacidade",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Combustivel",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "DataUltimaManutencao",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "PrecoDiaria",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Quilometragem",
                table: "carros");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "carros");
        }
    }
}
