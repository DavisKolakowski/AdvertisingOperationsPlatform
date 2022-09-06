﻿// <auto-generated />
using System;
using AOP.WebAPI.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AOP.WebAPI.Core.Data.Migrations
{
    [DbContext(typeof(AOPDatabaseContext))]
    [Migration("20220906180422_RemoveIdFromHeadquartersMarket")]
    partial class RemoveIdFromHeadquartersMarket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.DistributionServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("HeadquartersId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastSuccessfulDatabaseJob")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServerFolder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerIdentity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpotsLogFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SpotsLogLastWriteTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HeadquartersId");

                    b.ToTable("DistributionServers");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.DistributionServerSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DistributionServerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FirstAirDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SpotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistributionServerId");

                    b.HasIndex("SpotId");

                    b.ToTable("DistributionServerSpots");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.Headquarters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Headquarters");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.Spot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpotIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Spots");
                });

            modelBuilder.Entity("HeadquartersMarket", b =>
                {
                    b.Property<int>("HeadquartersId")
                        .HasColumnType("int");

                    b.Property<int>("MarketsId")
                        .HasColumnType("int");

                    b.HasKey("HeadquartersId", "MarketsId");

                    b.HasIndex("MarketsId");

                    b.ToTable("HeadquartersMarket");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.DistributionServer", b =>
                {
                    b.HasOne("AOP.WebAPI.Core.Data.Entities.Models.Headquarters", "Headquarters")
                        .WithMany("DistributionServers")
                        .HasForeignKey("HeadquartersId");

                    b.Navigation("Headquarters");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.DistributionServerSpot", b =>
                {
                    b.HasOne("AOP.WebAPI.Core.Data.Entities.Models.DistributionServer", "DistributionServer")
                        .WithMany("DistributionServerSpots")
                        .HasForeignKey("DistributionServerId");

                    b.HasOne("AOP.WebAPI.Core.Data.Entities.Models.Spot", "Spot")
                        .WithMany("DistributionServerSpots")
                        .HasForeignKey("SpotId");

                    b.Navigation("DistributionServer");

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("HeadquartersMarket", b =>
                {
                    b.HasOne("AOP.WebAPI.Core.Data.Entities.Models.Headquarters", null)
                        .WithMany()
                        .HasForeignKey("HeadquartersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AOP.WebAPI.Core.Data.Entities.Models.Market", null)
                        .WithMany()
                        .HasForeignKey("MarketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.DistributionServer", b =>
                {
                    b.Navigation("DistributionServerSpots");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.Headquarters", b =>
                {
                    b.Navigation("DistributionServers");
                });

            modelBuilder.Entity("AOP.WebAPI.Core.Data.Entities.Models.Spot", b =>
                {
                    b.Navigation("DistributionServerSpots");
                });
#pragma warning restore 612, 618
        }
    }
}