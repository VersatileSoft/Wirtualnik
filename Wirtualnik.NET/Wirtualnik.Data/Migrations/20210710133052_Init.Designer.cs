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
    [Migration("20210710133052_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Wirtualnik.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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
                    b.HasOne("Wirtualnik.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Wirtualnik.Data.Models.ApplicationUser", null)
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

                    b.HasOne("Wirtualnik.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Wirtualnik.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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