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
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provicia = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
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
                    ClientesClienteId = table.Column<int>(type: "int", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provicia = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxistas", x => x.TaxistaId);
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
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    personas = table.Column<int>(type: "int", nullable: false),
                    TaxistaId = table.Column<int>(type: "int", nullable: false),
                    ClientesClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.ViajeId);
                    table.ForeignKey(
                        name: "FK_Viajes_Clientes_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Viajes_Taxistas_TaxistaId",
                        column: x => x.TaxistaId,
                        principalTable: "Taxistas",
                        principalColumn: "TaxistaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    ImagenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.ImagenId);
                    table.ForeignKey(
                        name: "FK_Imagenes_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "ViajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Taxistas",
                columns: new[] { "TaxistaId", "ClientesClienteId", "Correo", "ExisteLicencia", "ExisteVehiculo", "FechaNacimiento", "NickName", "Password", "Provicia", "Role", "Status" },
                values: new object[,]
                {
                    { 1, null, "federicoLiranzo01@gmail.com", true, true, new DateTime(1985, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Federico Liranzo", "elcompa1985", null, 1, 1 },
                    { 2, null, "cesarpolanco1@gmail.com", true, true, new DateTime(1995, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cesar Polanco", "sorollo1995", null, 1, 1 },
                    { 3, null, "martinperez90@gmail.com", true, false, new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Perez", "eltino1990", null, 1, 1 },
                    { 4, null, "juanrodriguez87@gmail.com", false, true, new DateTime(1987, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Rodríguez", "rapido1987", null, 1, 1 },
                    { 5, null, "carlosherrera92@gmail.com", true, true, new DateTime(1992, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Herrera", "chico1992", null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Viajes",
                columns: new[] { "ViajeId", "ClientesClienteId", "Destino", "Estado", "Fecha", "Precio", "TaxistaId", "personas" },
                values: new object[,]
                {
                    { 1, null, " Bania de las aguilas", 2, new DateTime(2024, 11, 25, 11, 46, 21, 250, DateTimeKind.Local).AddTicks(9638), 2500.0, 1, 5 },
                    { 2, null, "Punta Cana", 2, new DateTime(2024, 11, 25, 11, 46, 21, 250, DateTimeKind.Local).AddTicks(9659), 3500.0, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenId", "Alt", "ImagenUrl", "Titulo", "ViajeId" },
                values: new object[,]
                {
                    { 1, "Imagen 1", "Images/Bahia-Aguilas.jpg", "Bahia de las aguilas", 1 },
                    { 2, "Imagen 2", "Images/camino-rocoso.jpg", "Camino roscoso", 1 },
                    { 3, "Imagen 3", "Images/Punta-Cana.jpg", "Punta cana", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_ViajeId",
                table: "Imagenes",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxistas_ClientesClienteId",
                table: "Taxistas",
                column: "ClientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ClientesClienteId",
                table: "Viajes",
                column: "ClientesClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_TaxistaId",
                table: "Viajes",
                column: "TaxistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Taxistas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
