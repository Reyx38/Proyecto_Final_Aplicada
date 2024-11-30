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
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                });

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
                name: "EstadosResrvaciones",
                columns: table => new
                {
                    EstadosRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosResrvaciones", x => x.EstadosRId);
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
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoVId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Recibo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    CantidadPasajeros = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.ReservacionId);
                    table.ForeignKey(
                        name: "FK_Reservaciones_EstadosResrvaciones_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosResrvaciones",
                        principalColumn: "EstadosRId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "ViajeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    ReservacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservacionDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservacionId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservacionDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ReservacionDetalles_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservacionDetalles_Reservaciones_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, 18.0, "Botella de agua", 150, 25.0 },
                    { 2, 20.0, "Jugo de naranja", 150, 35.0 },
                    { 3, 10.0, "Mani", 150, 30.0 },
                    { 4, 15.0, "FritoLay", 150, 35.0 },
                    { 5, 2.0, "Mentas", 250, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a91a5d7-71d7-452c-b27c-accbc77cc68c", null, "Taxista", "TAXISTA" },
                    { "69e0f8fc-a7f3-4340-9f98-f6b2b7b3a4c9", null, "Admin", "ADMIN" },
                    { "c804134c-3648-4d65-a24c-82dd8dda7787", null, "Cliente", "CLIENTE" }
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
                table: "EstadosResrvaciones",
                columns: new[] { "EstadosRId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "Aceptada" },
                    { 3, "Cancelada" }
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
                values: new object[] { 1, "Tarjeta de credito" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CiudadId", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "EstadoTId", "ExisteLicencia", "ExisteVehiculo", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "157fdd8b-c7fc-4e22-8045-99f0c275e16d", 0, 1, "adf49474-7c35-4ccf-8e19-bfe4c479d493", "Taxistas", "juanperez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword123", null, false, "1ad5880d-01ba-4599-a862-79244359aa31", false, "juanperez" },
                    { "423c7369-a45f-458f-9fea-7e38eb16bcef", 0, 2, "b4bdec70-41e2-425a-8f1d-ef1cf27312a0", "Taxistas", "carlosmendoza@example.com", false, 1, true, true, false, null, null, null, "hashedpassword789", null, false, "f3a28e0c-9006-4c50-b4a4-20de74ad01dd", false, "carlosmendoza" },
                    { "9c43efea-fd59-488d-90f8-7088172e97b0", 0, 1, "5b6982ac-2375-4937-bf07-639d7e85bd65", "Taxistas", "anafernandez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword102", null, false, "67747c43-07c9-4942-857f-f74cdf138d33", false, "anafernandez" },
                    { "d903c0ba-dcf0-44a9-99d0-08305c45f076", 0, 3, "a26056ae-2392-4ab5-86b0-cf7239c5bf5c", "Taxistas", "mariagonzalez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword456", null, false, "4544c0f1-e2c3-44ef-820b-cb473c718857", false, "mariagonzalez" },
                    { "f7b071c4-ea1b-4dc2-b148-25acb6f93740", 0, 2, "d3a5bead-0417-4a97-81f9-510c241924a8", "Taxistas", "luismartinez@example.com", false, 1, true, true, false, null, null, null, "hashedpassword101", null, false, "64a8f80a-d380-40e8-a81e-5d7d63c06f33", false, "luismartinez" }
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
                name: "IX_Pagos_ReservacionId",
                table: "Pagos",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionDetalles_ArticuloId",
                table: "ReservacionDetalles",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservacionDetalles_ReservacionId",
                table: "ReservacionDetalles",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_EstadoId",
                table: "Reservaciones",
                column: "EstadoId");

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
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "ReservacionDetalles");

            migrationBuilder.DropTable(
                name: "ViajesRapidos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "DestinosCerca");

            migrationBuilder.DropTable(
                name: "EstadosResrvaciones");

            migrationBuilder.DropTable(
                name: "Viajes");

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
