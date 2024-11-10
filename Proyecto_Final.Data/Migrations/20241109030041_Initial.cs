using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_Final.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Billeteras",
                columns: table => new
                {
                    BilleteraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billeteras", x => x.BilleteraId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BilleteraId = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provicia = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Billeteras_BilleteraId",
                        column: x => x.BilleteraId,
                        principalTable: "Billeteras",
                        principalColumn: "BilleteraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.TransaccionId);
                    table.ForeignKey(
                        name: "FK_Transacciones_Billeteras_TransaccionId",
                        column: x => x.TransaccionId,
                        principalTable: "Billeteras",
                        principalColumn: "BilleteraId",
                        onDelete: ReferentialAction.Cascade);
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
                    BilleteraId = table.Column<int>(type: "int", nullable: false),
                    ClientesClienteId = table.Column<int>(type: "int", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provicia = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxistas", x => x.TaxistaId);
                    table.ForeignKey(
                        name: "FK_Taxistas_Billeteras_BilleteraId",
                        column: x => x.BilleteraId,
                        principalTable: "Billeteras",
                        principalColumn: "BilleteraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxistas_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UbicacionInicial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tiempo = table.Column<TimeSpan>(type: "time", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TaxistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.ViajeId);
                    table.ForeignKey(
                        name: "FK_Viajes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Viajes_Taxistas_TaxistaId",
                        column: x => x.TaxistaId,
                        principalTable: "Taxistas",
                        principalColumn: "TaxistaId");
                });

            migrationBuilder.InsertData(
                table: "Billeteras",
                columns: new[] { "BilleteraId", "Saldo" },
                values: new object[,]
                {
                    { 1, 450.0 },
                    { 2, 450.0 },
                    { 3, 450.0 },
                    { 4, 450.0 },
                    { 5, 450.0 }
                });

            migrationBuilder.InsertData(
                table: "Taxistas",
                columns: new[] { "TaxistaId", "BilleteraId", "ClientesClienteId", "Correo", "ExisteLicencia", "ExisteVehiculo", "FechaNacimiento", "NickName", "Nombres", "Password", "Provicia", "Role", "Status" },
                values: new object[,]
                {
                    { 1, 1, null, "federicoLiranzo01@gmail.com", true, true, new DateTime(1985, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "El compa", "Federico Liranzo", "elcompa1985", 0, "Taxista", 1 },
                    { 2, 2, null, "cesarpolanco1@gmail.com", true, true, new DateTime(1995, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorollo", "Cesar Polanco", "sorollo1995", 0, "Taxista", 1 },
                    { 3, 3, null, "martinperez90@gmail.com", true, false, new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Tino", "Martin Perez", "eltino1990", 0, "Taxista", 1 },
                    { 4, 4, null, "juanrodriguez87@gmail.com", false, true, new DateTime(1987, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "El Rápido", "Juan Rodríguez", "rapido1987", 0, "Taxista", 1 },
                    { 5, 5, null, "carlosherrera92@gmail.com", true, true, new DateTime(1992, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chico", "Carlos Herrera", "chico1992", 0, "Taxista", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_BilleteraId",
                table: "Clientes",
                column: "BilleteraId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxistas_BilleteraId",
                table: "Taxistas",
                column: "BilleteraId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxistas_ClientesClienteId",
                table: "Taxistas",
                column: "ClientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ClienteId",
                table: "Viajes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_TaxistaId",
                table: "Viajes",
                column: "TaxistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Taxistas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Billeteras");
        }
    }
}
