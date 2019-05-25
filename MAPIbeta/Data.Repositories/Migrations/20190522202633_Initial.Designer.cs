﻿// <auto-generated />
using System;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace Data.Repositories.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20190522202633_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("Data.Entities.Calle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Coordinates");

                    b.Property<int>("ManzanaId");

                    b.Property<string>("Nombre");

                    b.Property<string>("Type");

                    b.Property<string>("Ubigeo");

                    b.HasKey("Id");

                    b.HasIndex("ManzanaId");

                    b.ToTable("Calles");
                });

            modelBuilder.Entity("Data.Entities.FeatureCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("FeatureCollection");
                });

            modelBuilder.Entity("Data.Entities.Features", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CalleGeomId");

                    b.Property<int?>("CallePropId");

                    b.Property<int?>("FeatureCollectionId");

                    b.Property<int?>("LoteGeomId");

                    b.Property<int?>("LotePropId");

                    b.Property<int?>("ManzanaGeomId");

                    b.Property<int?>("ManzanaPropId");

                    b.Property<int?>("ParcelaGeomId");

                    b.Property<int?>("ParcelaPropId");

                    b.Property<int?>("PuebloGeomId");

                    b.Property<int?>("PuebloPropId");

                    b.Property<string>("Type");

                    b.Property<int?>("UnidadTGeomId");

                    b.Property<int?>("UnidadTPropId");

                    b.Property<int>("fkey");

                    b.HasKey("Id");

                    b.HasIndex("CalleGeomId");

                    b.HasIndex("CallePropId");

                    b.HasIndex("FeatureCollectionId");

                    b.HasIndex("LoteGeomId");

                    b.HasIndex("LotePropId");

                    b.HasIndex("ManzanaGeomId");

                    b.HasIndex("ManzanaPropId");

                    b.HasIndex("ParcelaGeomId");

                    b.HasIndex("ParcelaPropId");

                    b.HasIndex("PuebloGeomId");

                    b.HasIndex("PuebloPropId");

                    b.HasIndex("UnidadTGeomId");

                    b.HasIndex("UnidadTPropId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Data.Entities.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Area");

                    b.Property<string>("ColinDer");

                    b.Property<string>("ColinFrnt");

                    b.Property<string>("ColinIzq");

                    b.Property<string>("ColinPost");

                    b.Property<string>("Coordinates");

                    b.Property<int>("ManzanaId");

                    b.Property<string>("MedidDer");

                    b.Property<string>("MedidFrnt");

                    b.Property<string>("MedidIzq");

                    b.Property<string>("MedidPost");

                    b.Property<string>("Nombre");

                    b.Property<string>("TipoUso");

                    b.Property<string>("Type");

                    b.Property<string>("Ubigeo");

                    b.HasKey("Id");

                    b.HasIndex("ManzanaId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("Data.Entities.Manzana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Area");

                    b.Property<int>("CantLotes");

                    b.Property<string>("Coordinates");

                    b.Property<string>("Nombre");

                    b.Property<int>("ParcelaId");

                    b.Property<int>("PuebloId");

                    b.Property<string>("Type");

                    b.Property<string>("Ubigeo");

                    b.HasKey("Id");

                    b.HasIndex("ParcelaId");

                    b.HasIndex("PuebloId");

                    b.ToTable("Manzanas");
                });

            modelBuilder.Entity("Data.Entities.Parcela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Area");

                    b.Property<string>("Coordinates");

                    b.Property<string>("Nombre");

                    b.Property<int>("PuebloId");

                    b.Property<string>("Type");

                    b.Property<string>("Ubigeo");

                    b.HasKey("Id");

                    b.HasIndex("PuebloId");

                    b.ToTable("Parcelas");
                });

            modelBuilder.Entity("Data.Entities.Pueblo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Area");

                    b.Property<double>("AreaComunal");

                    b.Property<double>("AreaEducacion");

                    b.Property<double>("AreaVivienda");

                    b.Property<int>("CantParcelas");

                    b.Property<string>("Coordinates");

                    b.Property<string>("Nombre");

                    b.Property<string>("Type");

                    b.Property<string>("Ubigeo");

                    b.Property<int>("UnidadTId");

                    b.HasKey("Id");

                    b.HasIndex("UnidadTId");

                    b.ToTable("Pueblos");
                });

            modelBuilder.Entity("Data.Entities.UnidadT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Coordinates");

                    b.Property<string>("Nombre");

                    b.Property<string>("Type");

                    b.Property<string>("Ubigeo");

                    b.HasKey("Id");

                    b.ToTable("UnidadTs");
                });

            modelBuilder.Entity("Data.Entities.Calle", b =>
                {
                    b.HasOne("Data.Entities.Manzana", "Manzana")
                        .WithMany("Calles")
                        .HasForeignKey("ManzanaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.Features", b =>
                {
                    b.HasOne("Data.Entities.Calle", "CalleGeom")
                        .WithMany()
                        .HasForeignKey("CalleGeomId");

                    b.HasOne("Data.Entities.Calle", "CalleProp")
                        .WithMany()
                        .HasForeignKey("CallePropId");

                    b.HasOne("Data.Entities.FeatureCollection")
                        .WithMany("Features")
                        .HasForeignKey("FeatureCollectionId");

                    b.HasOne("Data.Entities.Lote", "LoteGeom")
                        .WithMany()
                        .HasForeignKey("LoteGeomId");

                    b.HasOne("Data.Entities.Lote", "LoteProp")
                        .WithMany()
                        .HasForeignKey("LotePropId");

                    b.HasOne("Data.Entities.Manzana", "ManzanaGeom")
                        .WithMany()
                        .HasForeignKey("ManzanaGeomId");

                    b.HasOne("Data.Entities.Manzana", "ManzanaProp")
                        .WithMany()
                        .HasForeignKey("ManzanaPropId");

                    b.HasOne("Data.Entities.Parcela", "ParcelaGeom")
                        .WithMany()
                        .HasForeignKey("ParcelaGeomId");

                    b.HasOne("Data.Entities.Parcela", "ParcelaProp")
                        .WithMany()
                        .HasForeignKey("ParcelaPropId");

                    b.HasOne("Data.Entities.Pueblo", "PuebloGeom")
                        .WithMany()
                        .HasForeignKey("PuebloGeomId");

                    b.HasOne("Data.Entities.Pueblo", "PuebloProp")
                        .WithMany()
                        .HasForeignKey("PuebloPropId");

                    b.HasOne("Data.Entities.UnidadT", "UnidadTGeom")
                        .WithMany()
                        .HasForeignKey("UnidadTGeomId");

                    b.HasOne("Data.Entities.UnidadT", "UnidadTProp")
                        .WithMany()
                        .HasForeignKey("UnidadTPropId");
                });

            modelBuilder.Entity("Data.Entities.Lote", b =>
                {
                    b.HasOne("Data.Entities.Manzana", "Manzana")
                        .WithMany("Lotes")
                        .HasForeignKey("ManzanaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.Manzana", b =>
                {
                    b.HasOne("Data.Entities.Parcela", "Parcela")
                        .WithMany("Manzanas")
                        .HasForeignKey("ParcelaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Data.Entities.Pueblo", "Pueblo")
                        .WithMany("Manzanas")
                        .HasForeignKey("PuebloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.Parcela", b =>
                {
                    b.HasOne("Data.Entities.Pueblo", "Pueblo")
                        .WithMany("Parcelas")
                        .HasForeignKey("PuebloId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Entities.Pueblo", b =>
                {
                    b.HasOne("Data.Entities.UnidadT", "UnidadT")
                        .WithMany("Pueblos")
                        .HasForeignKey("UnidadTId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}