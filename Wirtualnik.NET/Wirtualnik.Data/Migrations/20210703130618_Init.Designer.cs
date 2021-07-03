﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wirtualnik.Data;

namespace Wirtualnik.Data.Migrations
{
    [DbContext(typeof(WirtualnikDbContext))]
    [Migration("20210703130618_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Wirtualnik.Data.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Archived")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EAN")
                        .HasColumnType("text");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

                    b.Property<string>("ManufacturerCode")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<string>("Series")
                        .HasColumnType("text");

                    b.Property<string>("ShortCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Warranty")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.ProductShop", b =>
                {
                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShopId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<string>("CleanLink")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("RefLink")
                        .HasColumnType("text");

                    b.HasKey("ProductId", "ShopId");

                    b.HasIndex("ShopId");

                    b.ToTable("ProductShop");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Shop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ApiLink")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Graphic", b =>
                {
                    b.HasBaseType("Wirtualnik.Data.Models.Product");

                    b.Property<string>("BaseCoreFreq")
                        .HasColumnType("text");

                    b.Property<string>("BoostCoreFreq")
                        .HasColumnType("text");

                    b.Property<string>("Chipset")
                        .HasColumnType("text")
                        .HasColumnName("Graphic_Chipset");

                    b.Property<string>("EightPinPower")
                        .HasColumnType("text");

                    b.Property<string>("Lenght")
                        .HasColumnType("text");

                    b.Property<string>("MemAmount")
                        .HasColumnType("text")
                        .HasColumnName("Graphic_MemAmount");

                    b.Property<string>("MemFreq")
                        .HasColumnType("text");

                    b.Property<string>("MemType")
                        .HasColumnType("text");

                    b.Property<bool>("RGB")
                        .HasColumnType("boolean")
                        .HasColumnName("Graphic_RGB");

                    b.Property<string>("SixPinPower")
                        .HasColumnType("text");

                    b.Property<string>("SlotType")
                        .HasColumnType("text");

                    b.Property<string>("TDP")
                        .HasColumnType("text")
                        .HasColumnName("Graphic_TDP");

                    b.Property<string>("Width")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Graphic");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.HardDisk", b =>
                {
                    b.HasBaseType("Wirtualnik.Data.Models.Product");

                    b.Property<string>("CacheAmount")
                        .HasColumnType("text");

                    b.Property<string>("Capacity")
                        .HasColumnType("text");

                    b.Property<string>("Heads")
                        .HasColumnType("text");

                    b.Property<string>("Interface")
                        .HasColumnType("text");

                    b.Property<string>("Platters")
                        .HasColumnType("text");

                    b.Property<string>("Rpm")
                        .HasColumnType("text");

                    b.Property<string>("ScoreOverall")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<string>("Weight")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("HardDisk");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Mainboard", b =>
                {
                    b.HasBaseType("Wirtualnik.Data.Models.Product");

                    b.Property<string>("ArgbHeaders")
                        .HasColumnType("text");

                    b.Property<string>("Chipset")
                        .HasColumnType("text");

                    b.Property<string>("DefaultGenSupport")
                        .HasColumnType("text");

                    b.Property<string>("EthernetCard")
                        .HasColumnType("text");

                    b.Property<string>("EthernetSpeed")
                        .HasColumnType("text");

                    b.Property<string>("FanHeaders")
                        .HasColumnType("text");

                    b.Property<string>("Format")
                        .HasColumnType("text");

                    b.Property<string>("M2Ports")
                        .HasColumnType("text");

                    b.Property<string>("RamMaxAmount")
                        .HasColumnType("text");

                    b.Property<string>("RamMaxFreq")
                        .HasColumnType("text");

                    b.Property<string>("RamSlots")
                        .HasColumnType("text");

                    b.Property<string>("SataPorts")
                        .HasColumnType("text");

                    b.Property<string>("Socket")
                        .HasColumnType("text")
                        .HasColumnName("Mainboard_Socket");

                    b.Property<string>("Soundcard")
                        .HasColumnType("text");

                    b.Property<string>("UpdateGenSupport")
                        .HasColumnType("text");

                    b.Property<string>("VrmDetails")
                        .HasColumnType("text");

                    b.Property<string>("VrmPhases")
                        .HasColumnType("text");

                    b.Property<string>("VrmRating")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Mainboard");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Memory", b =>
                {
                    b.HasBaseType("Wirtualnik.Data.Models.Product");

                    b.Property<string>("MemAmount")
                        .HasColumnType("text");

                    b.Property<string>("MemPerModule")
                        .HasColumnType("text");

                    b.Property<string>("ModuleHeight")
                        .HasColumnType("text");

                    b.Property<string>("Modules")
                        .HasColumnType("text");

                    b.Property<bool>("RGB")
                        .HasColumnType("boolean");

                    b.Property<bool>("Radiator")
                        .HasColumnType("boolean");

                    b.Property<string>("SpdFreq")
                        .HasColumnType("text");

                    b.Property<string>("SpdVoltage")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("XmpFreq")
                        .HasColumnType("text");

                    b.Property<string>("XmpLatency")
                        .HasColumnType("text");

                    b.Property<string>("XmpVoltage")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Memory");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Processor", b =>
                {
                    b.HasBaseType("Wirtualnik.Data.Models.Product");

                    b.Property<string>("Architecture")
                        .HasColumnType("text");

                    b.Property<string>("BaseFrequency")
                        .HasColumnType("text");

                    b.Property<string>("BoostFrequency")
                        .HasColumnType("text");

                    b.Property<string>("CacheL1")
                        .HasColumnType("text");

                    b.Property<string>("CacheL2")
                        .HasColumnType("text");

                    b.Property<string>("CacheL3")
                        .HasColumnType("text");

                    b.Property<string>("Cooler")
                        .HasColumnType("text");

                    b.Property<string>("Cores")
                        .HasColumnType("text");

                    b.Property<string>("IGPU")
                        .HasColumnType("text");

                    b.Property<string>("Lithography")
                        .HasColumnType("text");

                    b.Property<string>("RamFreq")
                        .HasColumnType("text");

                    b.Property<string>("ScoreCinebenchMulti")
                        .HasColumnType("text");

                    b.Property<string>("ScoreCinebenchSingle")
                        .HasColumnType("text");

                    b.Property<string>("ScoreDesktopPerf")
                        .HasColumnType("text");

                    b.Property<string>("ScoreGamingPerf")
                        .HasColumnType("text");

                    b.Property<string>("ScoreProPerf")
                        .HasColumnType("text");

                    b.Property<string>("Socket")
                        .HasColumnType("text");

                    b.Property<string>("SocketGen")
                        .HasColumnType("text");

                    b.Property<string>("TDP")
                        .HasColumnType("text");

                    b.Property<string>("Threads")
                        .HasColumnType("text");

                    b.Property<bool>("Unlocked")
                        .HasColumnType("boolean");

                    b.HasDiscriminator().HasValue("Processor");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.SolidStateDrive", b =>
                {
                    b.HasBaseType("Wirtualnik.Data.Models.Product");

                    b.Property<string>("Capacity")
                        .HasColumnType("text")
                        .HasColumnName("SolidStateDrive_Capacity");

                    b.Property<string>("Controller")
                        .HasColumnType("text");

                    b.Property<string>("Interface")
                        .HasColumnType("text")
                        .HasColumnName("SolidStateDrive_Interface");

                    b.Property<string>("MemoryType")
                        .HasColumnType("text");

                    b.Property<bool>("Radiator")
                        .HasColumnType("boolean")
                        .HasColumnName("SolidStateDrive_Radiator");

                    b.Property<string>("RandRead")
                        .HasColumnType("text");

                    b.Property<string>("RandWrite")
                        .HasColumnType("text");

                    b.Property<string>("ScoreOverall")
                        .HasColumnType("text")
                        .HasColumnName("SolidStateDrive_ScoreOverall");

                    b.Property<string>("ScoreSustained")
                        .HasColumnType("text");

                    b.Property<string>("SeqRead")
                        .HasColumnType("text");

                    b.Property<string>("SeqWrite")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text")
                        .HasColumnName("SolidStateDrive_Size");

                    b.Property<string>("Tbw")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("SolidStateDrive");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.ProductShop", b =>
                {
                    b.HasOne("Wirtualnik.Data.Models.Product", "Product")
                        .WithMany("ProductShops")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wirtualnik.Data.Models.Shop", "Shop")
                        .WithMany("ProductShops")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Product", b =>
                {
                    b.Navigation("ProductShops");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Shop", b =>
                {
                    b.Navigation("ProductShops");
                });
#pragma warning restore 612, 618
        }
    }
}