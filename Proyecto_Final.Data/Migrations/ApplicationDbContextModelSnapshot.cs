﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReyAI_Trasport.Data.Contexto;

#nullable disable

namespace Proyecto_Final.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "40569742-eaff-43db-ab6f-d5c1d8fed1ec",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "145c1c31-f7ff-4159-83a3-7d4452abcac3",
                            Name = "Taxista",
                            NormalizedName = "TAXISTA"
                        },
                        new
                        {
                            Id = "692b7ed5-31ed-4a7b-99b5-f1122035519b",
                            Name = "Cliente",
                            NormalizedName = "CLIENTE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 18.0,
                            Descripcion = "Botella de agua",
                            Existencia = 150,
                            Precio = 25.0
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 20.0,
                            Descripcion = "Jugo de naranja",
                            Existencia = 150,
                            Precio = 35.0
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 10.0,
                            Descripcion = "Mani",
                            Existencia = 150,
                            Precio = 30.0
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 15.0,
                            Descripcion = "FritoLay",
                            Existencia = 150,
                            Precio = 35.0
                        },
                        new
                        {
                            ArticuloId = 5,
                            Costo = 2.0,
                            Descripcion = "Mentas",
                            Existencia = 250,
                            Precio = 5.0
                        });
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.Ciudades", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CiudadId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CiudadId");

                    b.ToTable("Ciudades");

                    b.HasData(
                        new
                        {
                            CiudadId = 1,
                            Nombre = "San Francisco de Macoris"
                        },
                        new
                        {
                            CiudadId = 2,
                            Nombre = "Santo Domingo"
                        },
                        new
                        {
                            CiudadId = 3,
                            Nombre = "Santigo"
                        },
                        new
                        {
                            CiudadId = 4,
                            Nombre = "Samana"
                        },
                        new
                        {
                            CiudadId = 5,
                            Nombre = "Puerto Plata"
                        });
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.DestinosCerca", b =>
                {
                    b.Property<int>("DestinoCercaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestinoCercaId"));

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinoCercaId");

                    b.HasIndex("CiudadId");

                    b.ToTable("DestinosCerca");

                    b.HasData(
                        new
                        {
                            DestinoCercaId = 1,
                            CiudadId = 1,
                            Descripcion = "Parque Duarte"
                        },
                        new
                        {
                            DestinoCercaId = 2,
                            CiudadId = 1,
                            Descripcion = "La sirena"
                        },
                        new
                        {
                            DestinoCercaId = 3,
                            CiudadId = 1,
                            Descripcion = "Supermercado Bravo"
                        },
                        new
                        {
                            DestinoCercaId = 4,
                            CiudadId = 1,
                            Descripcion = "El mercado"
                        });
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.EstadosTaxistas", b =>
                {
                    b.Property<int>("EstadoTId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoTId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoTId");

                    b.ToTable("EstadosTaxistas");

                    b.HasData(
                        new
                        {
                            EstadoTId = 1,
                            Descripcion = "Disponible"
                        },
                        new
                        {
                            EstadoTId = 2,
                            Descripcion = "Ocupado"
                        });
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.EstadosViajes", b =>
                {
                    b.Property<int>("EstadosVId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadosVId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadosVId");

                    b.ToTable("EstadosViajes");

                    b.HasData(
                        new
                        {
                            EstadosVId = 1,
                            Descripcion = "Pendiente"
                        },
                        new
                        {
                            EstadosVId = 2,
                            Descripcion = "En Curso"
                        },
                        new
                        {
                            EstadosVId = 3,
                            Descripcion = "Completado"
                        },
                        new
                        {
                            EstadosVId = 4,
                            Descripcion = "Cancelado"
                        });
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.MetodosPagos", b =>
                {
                    b.Property<int>("MetodoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MetodoPagoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MetodoPagoId");

                    b.ToTable("MetodosPagos");

                    b.HasData(
                        new
                        {
                            MetodoPagoId = 1,
                            Descripcion = "Efectivo"
                        },
                        new
                        {
                            MetodoPagoId = 2,
                            Descripcion = "Tarjeta de credito"
                        });
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.ReservacionDetalles", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("ReservacionId")
                        .HasColumnType("int");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("ReservacionId");

                    b.ToTable("ReservacionDetalles");
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.Reservaciones", b =>
                {
                    b.Property<int>("ReservacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservacionId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.Property<string>("Recibo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViajeId")
                        .HasColumnType("int");

                    b.HasKey("ReservacionId");

                    b.HasIndex("ViajeId");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.ViajesRapidos", b =>
                {
                    b.Property<int>("ViajeRapidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViajeRapidoId"));

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DestinoCercaId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoVId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<string>("TaxistaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("personas")
                        .HasColumnType("int");

                    b.HasKey("ViajeRapidoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DestinoCercaId");

                    b.HasIndex("EstadoVId");

                    b.HasIndex("TaxistaId");

                    b.ToTable("ViajesRapidos");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Imagen", b =>
                {
                    b.Property<int>("ImagenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImagenId"));

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Base64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ViajeId")
                        .HasColumnType("int");

                    b.HasKey("ImagenId");

                    b.HasIndex("ViajeId");

                    b.ToTable("Imagen");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Viajes", b =>
                {
                    b.Property<int>("ViajeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViajeId"));

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Destino")
                        .HasColumnType("int");

                    b.Property<int>("EstadoVId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<string>("TaxistaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("personas")
                        .HasColumnType("int");

                    b.HasKey("ViajeId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ClientesId");

                    b.HasIndex("EstadoVId");

                    b.HasIndex("TaxistaId");

                    b.ToTable("Viajes");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Clientes", b =>
                {
                    b.HasBaseType("ReyAI_Trasport.Data.ApplicationUser");

                    b.HasDiscriminator().HasValue("Clientes");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Taxistas", b =>
                {
                    b.HasBaseType("ReyAI_Trasport.Data.ApplicationUser");

                    b.Property<int>("EstadoTId")
                        .HasColumnType("int");

                    b.Property<bool>("ExisteLicencia")
                        .HasColumnType("bit");

                    b.Property<bool>("ExisteVehiculo")
                        .HasColumnType("bit");

                    b.HasIndex("EstadoTId");

                    b.HasDiscriminator().HasValue("Taxistas");

                    b.HasData(
                        new
                        {
                            Id = "72a32439-8857-47cd-86d3-fb8be43fc2d1",
                            AccessFailedCount = 0,
                            CiudadId = 1,
                            ConcurrencyStamp = "9183d96e-3c08-4256-968a-1f24f2e169ff",
                            Email = "juanperez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "86801ef6-08d1-4c9e-bc71-d4793318bbe8",
                            TwoFactorEnabled = false,
                            UserName = "juanperez",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = true
                        },
                        new
                        {
                            Id = "7d0b9b2b-e276-421e-91b4-4e259ebaf650",
                            AccessFailedCount = 0,
                            CiudadId = 3,
                            ConcurrencyStamp = "c294ae4a-2569-4f2d-aecb-f07f8a1f7a38",
                            Email = "mariagonzalez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5a3bb600-c6dd-428d-b453-9c34f41f9aef",
                            TwoFactorEnabled = false,
                            UserName = "mariagonzalez",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = true
                        },
                        new
                        {
                            Id = "3668a51b-4b14-435f-95aa-4477c050187c",
                            AccessFailedCount = 0,
                            CiudadId = 2,
                            ConcurrencyStamp = "fbce1d9c-38a1-497f-9805-5d68dc485680",
                            Email = "carlosmendoza@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0e4a0958-471e-4a69-a853-98a0642c15bb",
                            TwoFactorEnabled = false,
                            UserName = "carlosmendoza",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = true
                        },
                        new
                        {
                            Id = "5dc6b3ff-c9b6-4b80-bd1a-5ed79b0708c2",
                            AccessFailedCount = 0,
                            CiudadId = 2,
                            ConcurrencyStamp = "1fc3eaf0-6041-44a4-916e-5140ce3b07a1",
                            Email = "luismartinez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword101",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b436b178-d663-4cdd-8e5f-60acceb0aaa3",
                            TwoFactorEnabled = false,
                            UserName = "luismartinez",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = true
                        },
                        new
                        {
                            Id = "10b8f86d-0620-4769-8a5e-e72ba11aab51",
                            AccessFailedCount = 0,
                            CiudadId = 1,
                            ConcurrencyStamp = "74a4b9c6-e5a8-45d5-b561-ab18667dc26f",
                            Email = "anafernandez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword102",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7107a9fe-97f6-4f35-a3c3-23ee039c49bf",
                            TwoFactorEnabled = false,
                            UserName = "anafernandez",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = true
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.ApplicationUser", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.Models.Ciudades", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId");

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.DestinosCerca", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.Models.Ciudades", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.ReservacionDetalles", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.Models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReyAI_Trasport.Data.Models.Reservaciones", "Reservacion")
                        .WithMany("ReservacionDetalles")
                        .HasForeignKey("ReservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Reservacion");
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.Reservaciones", b =>
                {
                    b.HasOne("ReyAI_Trasport.Domain.Models.Viajes", "Viaje")
                        .WithMany()
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Viaje");
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.ViajesRapidos", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("ReyAI_Trasport.Data.Models.DestinosCerca", "DestinoCerca")
                        .WithMany()
                        .HasForeignKey("DestinoCercaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReyAI_Trasport.Data.Models.EstadosViajes", "EstadoViaje")
                        .WithMany()
                        .HasForeignKey("EstadoVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", "Taxista")
                        .WithMany()
                        .HasForeignKey("TaxistaId");

                    b.Navigation("Cliente");

                    b.Navigation("DestinoCerca");

                    b.Navigation("EstadoViaje");

                    b.Navigation("Taxista");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Imagen", b =>
                {
                    b.HasOne("ReyAI_Trasport.Domain.Models.Viajes", "Viaje")
                        .WithMany("Imagen")
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Viaje");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Viajes", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("ReyAI_Trasport.Domain.Models.Clientes", null)
                        .WithMany("Viajes")
                        .HasForeignKey("ClientesId");

                    b.HasOne("ReyAI_Trasport.Data.Models.EstadosViajes", "EstadoViaje")
                        .WithMany()
                        .HasForeignKey("EstadoVId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReyAI_Trasport.Data.ApplicationUser", "Taxista")
                        .WithMany()
                        .HasForeignKey("TaxistaId");

                    b.Navigation("Cliente");

                    b.Navigation("EstadoViaje");

                    b.Navigation("Taxista");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Taxistas", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.Models.EstadosTaxistas", "EstadoTaxista")
                        .WithMany()
                        .HasForeignKey("EstadoTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoTaxista");
                });

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.Reservaciones", b =>
                {
                    b.Navigation("ReservacionDetalles");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Viajes", b =>
                {
                    b.Navigation("Imagen");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Clientes", b =>
                {
                    b.Navigation("Viajes");
                });
#pragma warning restore 612, 618
        }
    }
}
