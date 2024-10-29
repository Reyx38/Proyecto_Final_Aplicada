using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_Final_Aplicada.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Taxistas",
                columns: table => new
                {
                    TaxistaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExisteVehiculo = table.Column<bool>(type: "bit", nullable: false),
                    ExisteLicencia = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxistas", x => x.TaxistaId);
                });

            migrationBuilder.InsertData(
                table: "Taxistas",
                columns: new[] { "TaxistaId", "Correo", "ExisteLicencia", "ExisteVehiculo", "FechaNacimiento", "NickName", "Nombres", "Password", "Status" },
                values: new object[,]
                {
                    { 1, "federicoLiranzo01@gmail.com", true, true, new DateTime(1985, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "El compa", "Federico Liranzo", "elcompa1985", 1 },
                    { 2, "cesarpolanco1@gmail.com", true, true, new DateTime(1995, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorollo", "Cesar Polanco", "sorollo1995", 1 },
                    { 3, "martinperez90@gmail.com", true, false, new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Tino", "Martin Perez", "eltino1990", 1 },
                    { 4, "juanrodriguez87@gmail.com", false, true, new DateTime(1987, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Rápido", "Juan Rodríguez", "rapido1987", 1 },
                    { 5, "carlosherrera92@gmail.com", true, true, new DateTime(1992, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chico", "Carlos Herrera", "chico1992", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Taxistas");
        }
    }
}
