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
                            Id = "b3ffa056-46a9-40cc-9442-ed9a773c665a",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "79c4feb8-36fd-4c22-8f61-a28688e21a5d",
                            Name = "Taxista",
                            NormalizedName = "TAXISTA"
                        },
                        new
                        {
                            Id = "65c21308-9f1e-46ae-9351-be0fec36e14e",
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

                    b.Property<string>("ClientesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EstadoTId")
                        .HasColumnType("int");

                    b.Property<bool>("ExisteLicencia")
                        .HasColumnType("bit");

                    b.Property<bool>("ExisteVehiculo")
                        .HasColumnType("bit");

                    b.HasIndex("ClientesId");

                    b.HasIndex("EstadoTId");

                    b.HasDiscriminator().HasValue("Taxistas");

                    b.HasData(
                        new
                        {
                            Id = "d6d8cbfd-a5d3-4f96-a1f4-37b07bb900eb",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fc15f2a4-8d8f-4b3e-b794-b5f8d324a09f",
                            Email = "juanperez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "aff05819-5a87-4d48-a318-332d5e7b90d4",
                            TwoFactorEnabled = false,
                            UserName = "juanperez",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = true
                        },
                        new
                        {
                            Id = "84b0f5dc-5341-45b4-901d-62e46ed363ae",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fbb7bc98-3e2a-4f48-b091-90af8b4e7200",
                            Email = "mariagonzalez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword456",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8f0587b6-137d-4d32-9b26-66306e027f30",
                            TwoFactorEnabled = false,
                            UserName = "mariagonzalez",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = true
                        },
                        new
                        {
                            Id = "29f18fcd-bdb4-46e1-9ec1-615554f95827",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9c395037-97e8-49f2-a2db-14cbc37933aa",
                            Email = "carlosmendoza@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d00de59f-1ab0-46df-953b-9903ab25b04e",
                            TwoFactorEnabled = false,
                            UserName = "carlosmendoza",
                            EstadoTId = 1,
                            ExisteLicencia = true,
                            ExisteVehiculo = false
                        },
                        new
                        {
                            Id = "2067cbf5-9ca8-4fb0-b98b-cb30cef338c6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9bde95d7-4a4f-42bb-a6fd-f331bc73d71c",
                            Email = "luismartinez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword101",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d4bd4277-f08a-43f5-b014-a012cc9a020c",
                            TwoFactorEnabled = false,
                            UserName = "luismartinez",
                            EstadoTId = 1,
                            ExisteLicencia = false,
                            ExisteVehiculo = true
                        },
                        new
                        {
                            Id = "2974c9ee-2be0-4eca-aa9c-3b69c04753cd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a0014fb9-0309-4f0c-9eb8-c41d19531c83",
                            Email = "anafernandez@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "hashedpassword102",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f4bbd97e-50b1-4bd7-9007-138aac10f5fb",
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

            modelBuilder.Entity("ReyAI_Trasport.Data.Models.DestinosCerca", b =>
                {
                    b.HasOne("ReyAI_Trasport.Data.Models.Ciudades", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
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
                    b.HasOne("ReyAI_Trasport.Domain.Models.Clientes", null)
                        .WithMany("Favoritos")
                        .HasForeignKey("ClientesId");

                    b.HasOne("ReyAI_Trasport.Data.Models.EstadosTaxistas", "EstadoTaxista")
                        .WithMany()
                        .HasForeignKey("EstadoTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoTaxista");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Viajes", b =>
                {
                    b.Navigation("Imagen");
                });

            modelBuilder.Entity("ReyAI_Trasport.Domain.Models.Clientes", b =>
                {
                    b.Navigation("Favoritos");

                    b.Navigation("Viajes");
                });
#pragma warning restore 612, 618
        }
    }
}
