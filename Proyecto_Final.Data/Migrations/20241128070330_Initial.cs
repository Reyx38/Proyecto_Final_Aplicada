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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosTaxistas",
                columns: table => new
                {
                    EstadoTId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosTaxistas", x => x.EstadoTId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosViajes",
                columns: table => new
                {
                    EstadosVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosViajes", x => x.EstadosVId);
                });

            migrationBuilder.CreateTable(
                name: "MetodosPagos",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPagos", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinosCerca",
                columns: table => new
                {
                    DestinoCercaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinosCerca", x => x.DestinoCercaId);
                    table.ForeignKey(
                        name: "FK_DestinosCerca_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    ExisteVehiculo = table.Column<bool>(type: "bit", nullable: true),
                    ExisteLicencia = table.Column<bool>(type: "bit", nullable: true),
                    EstadoTId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_EstadosTaxistas_EstadoTId",
                        column: x => x.EstadoTId,
                        principalTable: "EstadosTaxistas",
                        principalColumn: "EstadoTId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destino = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoVId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    personas = table.Column<int>(type: "int", nullable: false),
                    TaxistaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClientesId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.ViajeId);
                    table.ForeignKey(
                        name: "FK_Viajes_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_AspNetUsers_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_AspNetUsers_TaxistaId",
                        column: x => x.TaxistaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Viajes_EstadosViajes_EstadoVId",
                        column: x => x.EstadoVId,
                        principalTable: "EstadosViajes",
                        principalColumn: "EstadosVId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViajesRapidos",
                columns: table => new
                {
                    ViajeRapidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoCercaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoVId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    personas = table.Column<int>(type: "int", nullable: false),
                    TaxistaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajesRapidos", x => x.ViajeRapidoId);
                    table.ForeignKey(
                        name: "FK_ViajesRapidos_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ViajesRapidos_AspNetUsers_TaxistaId",
                        column: x => x.TaxistaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ViajesRapidos_DestinosCerca_DestinoCercaId",
                        column: x => x.DestinoCercaId,
                        principalTable: "DestinosCerca",
                        principalColumn: "DestinoCercaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViajesRapidos_EstadosViajes_EstadoVId",
                        column: x => x.EstadoVId,
                        principalTable: "EstadosViajes",
                        principalColumn: "EstadosVId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagen",
                columns: table => new
                {
                    ImagenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagen", x => x.ImagenId);
                    table.ForeignKey(
                        name: "FK_Imagen_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "ViajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    ReservacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViajeId = table.Column<int>(type: "int", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    Recibo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.ReservacionId);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "ViajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "269b1aec-c431-4830-b2f1-6a0443b73b0d", null, "Taxista", "TAXISTA" },
                    { "7279a2c9-95c4-4b2b-8c7e-905e9fb6aeb0", null, "Admin", "ADMIN" },
                    { "cd211c4f-13ac-4b08-a044-f2d8d89a29e9", null, "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "CiudadId", "Nombre" },
                values: new object[,]
                {
                    { 1, "San Francisco de Macoris" },
                    { 2, "Santo Domingo" },
                    { 3, "Santigo" },
                    { 4, "Samana" },
                    { 5, "Puerto Plata" }
                });

            migrationBuilder.InsertData(
                table: "EstadosTaxistas",
                columns: new[] { "EstadoTId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Ocupado" }
                });

            migrationBuilder.InsertData(
                table: "EstadosViajes",
                columns: new[] { "EstadosVId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "En Curso" },
                    { 3, "Completado" },
                    { 4, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "MetodosPagos",
                columns: new[] { "MetodoPagoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de credito" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CiudadId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EstadoTId", "ExisteLicencia", "ExisteVehiculo", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0ec518ee-8998-4763-8644-dd25d9b9a4c7", 0, 2, "c957d859-0f3f-4a8e-89c6-f5b20a03084e", "Taxistas", "luismartinez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword101", null, false, "da6a0311-5c45-4ad0-bd8c-8a72cd04f493", false, "luismartinez" },
                    { "51734258-7f5c-4479-80bf-365e4b2930e3", 0, 3, "7b25c117-c1c2-4a11-bb40-6ccd554e6700", "Taxistas", "mariagonzalez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword456", null, false, "4c03e26e-ddc0-440c-ba11-62733aa27b3b", false, "mariagonzalez" },
                    { "838f3d2b-ff85-45b3-a4fa-84ecc58f31a8", 0, 1, "2e5083bb-12a9-4ba3-ad1a-662f109ac84d", "Taxistas", "anafernandez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword102", null, false, "49d800fe-546c-4f5f-9f2e-cb1c0c99d4a1", false, "anafernandez" },
                    { "d7c67acf-9a2c-4d25-a974-a311c095241c", 0, 1, "d49ddcf7-b4c0-4efc-a5d4-9005d8c3294e", "Taxistas", "juanperez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword123", null, false, "fcefd1f5-2d43-4521-b77e-0fd1a8de2344", false, "juanperez" },
                    { "e08e2475-6cd1-4f43-8f40-d771af2e4131", 0, 2, "afe87f32-9211-4028-bb25-9d3dd49bad39", "Taxistas", "carlosmendoza@example.com", false, 1, true, true, false, null, null, null, "hashedpassword789", null, false, "292be613-5cb1-4245-9eae-d07af7744bfc", false, "carlosmendoza" }
                });

            migrationBuilder.InsertData(
                table: "DestinosCerca",
                columns: new[] { "DestinoCercaId", "CiudadId", "Descripcion" },
                values: new object[,]
                {
                    { 1, 1, "Parque Duarte" },
                    { 2, 1, "La sirena" },
                    { 3, 1, "Supermercado Bravo" },
                    { 4, 1, "El mercado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CiudadId",
                table: "AspNetUsers",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EstadoTId",
                table: "AspNetUsers",
                column: "EstadoTId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DestinosCerca_CiudadId",
                table: "DestinosCerca",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagen_ViajeId",
                table: "Imagen",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_ViajeId",
                table: "Reservaciones",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ClienteId",
                table: "Viajes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ClientesId",
                table: "Viajes",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_EstadoVId",
                table: "Viajes",
                column: "EstadoVId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_TaxistaId",
                table: "Viajes",
                column: "TaxistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesRapidos_ClienteId",
                table: "ViajesRapidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesRapidos_DestinoCercaId",
                table: "ViajesRapidos",
                column: "DestinoCercaId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesRapidos_EstadoVId",
                table: "ViajesRapidos",
                column: "EstadoVId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesRapidos_TaxistaId",
                table: "ViajesRapidos",
                column: "TaxistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Imagen");

            migrationBuilder.DropTable(
                name: "MetodosPagos");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "ViajesRapidos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "DestinosCerca");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EstadosViajes");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "EstadosTaxistas");
        }
    }
}
