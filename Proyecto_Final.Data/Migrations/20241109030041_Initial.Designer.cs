﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Final.Data.Contexto;

#nullable disable

namespace Proyecto_Final.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241109030041_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto_Final.Data.Models.Billeteras", b =>
                {
                    b.Property<int>("BilleteraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BilleteraId"));

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("BilleteraId");

                    b.ToTable("Billeteras");

                    b.HasData(
                        new
                        {
                            BilleteraId = 1,
                            Saldo = 450.0
                        },
                        new
                        {
                            BilleteraId = 2,
                            Saldo = 450.0
                        },
                        new
                        {
                            BilleteraId = 3,
                            Saldo = 450.0
                        },
                        new
                        {
                            BilleteraId = 4,
                            Saldo = 450.0
                        },
                        new
                        {
                            BilleteraId = 5,
                            Saldo = 450.0
                        });
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<int>("BilleteraId")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Provicia")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("BilleteraId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Taxistas", b =>
                {
                    b.Property<int>("TaxistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxistaId"));

                    b.Property<int>("BilleteraId")
                        .HasColumnType("int");

                    b.Property<int?>("ClientesClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ExisteLicencia")
                        .HasColumnType("bit");

                    b.Property<bool>("ExisteVehiculo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Provicia")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("TaxistaId");

                    b.HasIndex("BilleteraId");

                    b.HasIndex("ClientesClienteId");

                    b.ToTable("Taxistas");

                    b.HasData(
                        new
                        {
                            TaxistaId = 1,
                            BilleteraId = 1,
                            Correo = "federicoLiranzo01@gmail.com",
                            ExisteLicencia = true,
                            ExisteVehiculo = true,
                            FechaNacimiento = new DateTime(1985, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NickName = "El compa",
                            Nombres = "Federico Liranzo",
                            Password = "elcompa1985",
                            Provicia = 0,
                            Role = "Taxista",
                            Status = 1
                        },
                        new
                        {
                            TaxistaId = 2,
                            BilleteraId = 2,
                            Correo = "cesarpolanco1@gmail.com",
                            ExisteLicencia = true,
                            ExisteVehiculo = true,
                            FechaNacimiento = new DateTime(1995, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NickName = "Sorollo",
                            Nombres = "Cesar Polanco",
                            Password = "sorollo1995",
                            Provicia = 0,
                            Role = "Taxista",
                            Status = 1
                        },
                        new
                        {
                            TaxistaId = 3,
                            BilleteraId = 3,
                            Correo = "martinperez90@gmail.com",
                            ExisteLicencia = true,
                            ExisteVehiculo = false,
                            FechaNacimiento = new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NickName = "El Tino",
                            Nombres = "Martin Perez",
                            Password = "eltino1990",
                            Provicia = 0,
                            Role = "Taxista",
                            Status = 1
                        },
                        new
                        {
                            TaxistaId = 4,
                            BilleteraId = 4,
                            Correo = "juanrodriguez87@gmail.com",
                            ExisteLicencia = false,
                            ExisteVehiculo = true,
                            FechaNacimiento = new DateTime(1987, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NickName = "El Rápido",
                            Nombres = "Juan Rodríguez",
                            Password = "rapido1987",
                            Provicia = 0,
                            Role = "Taxista",
                            Status = 1
                        },
                        new
                        {
                            TaxistaId = 5,
                            BilleteraId = 5,
                            Correo = "carlosherrera92@gmail.com",
                            ExisteLicencia = true,
                            ExisteVehiculo = true,
                            FechaNacimiento = new DateTime(1992, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NickName = "Chico",
                            Nombres = "Carlos Herrera",
                            Password = "chico1992",
                            Provicia = 0,
                            Role = "Taxista",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Transacciones", b =>
                {
                    b.Property<int>("TransaccionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("TransaccionId");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Viajes", b =>
                {
                    b.Property<int>("ViajeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ViajeId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("TaxistaId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Tiempo")
                        .HasColumnType("time");

                    b.Property<string>("UbicacionInicial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ViajeId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TaxistaId");

                    b.ToTable("Viajes");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Clientes", b =>
                {
                    b.HasOne("Proyecto_Final.Data.Models.Billeteras", "Billetera")
                        .WithMany()
                        .HasForeignKey("BilleteraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billetera");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Taxistas", b =>
                {
                    b.HasOne("Proyecto_Final.Data.Models.Billeteras", "Billetera")
                        .WithMany()
                        .HasForeignKey("BilleteraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Final.Data.Models.Clientes", null)
                        .WithMany("Favoritos")
                        .HasForeignKey("ClientesClienteId");

                    b.Navigation("Billetera");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Transacciones", b =>
                {
                    b.HasOne("Proyecto_Final.Data.Models.Billeteras", null)
                        .WithMany("Transacciones")
                        .HasForeignKey("TransaccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Viajes", b =>
                {
                    b.HasOne("Proyecto_Final.Data.Models.Clientes", "Cliente")
                        .WithMany("Viajes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Proyecto_Final.Data.Models.Taxistas", "Taxista")
                        .WithMany("Viajes")
                        .HasForeignKey("TaxistaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Taxista");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Billeteras", b =>
                {
                    b.Navigation("Transacciones");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Clientes", b =>
                {
                    b.Navigation("Favoritos");

                    b.Navigation("Viajes");
                });

            modelBuilder.Entity("Proyecto_Final.Data.Models.Taxistas", b =>
                {
                    b.Navigation("Viajes");
                });
#pragma warning restore 612, 618
        }
    }
}
