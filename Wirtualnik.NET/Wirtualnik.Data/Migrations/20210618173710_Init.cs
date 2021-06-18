using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Wirtualnik.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HardDisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Heads = table.Column<string>(type: "text", nullable: true),
                    Platters = table.Column<string>(type: "text", nullable: true),
                    CacheAmount = table.Column<string>(type: "text", nullable: true),
                    Rpm = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<string>(type: "text", nullable: true),
                    Interface = table.Column<string>(type: "text", nullable: true),
                    ScoreOverall = table.Column<string>(type: "text", nullable: true),
                    EAN = table.Column<string>(type: "text", nullable: true),
                    ShortCode = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCode = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Warranty = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Morele_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_RefLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Xkom_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_RefLink = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDisks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mainboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Chipset = table.Column<string>(type: "text", nullable: true),
                    Socket = table.Column<string>(type: "text", nullable: true),
                    VrmRating = table.Column<string>(type: "text", nullable: true),
                    VrmPhases = table.Column<string>(type: "text", nullable: true),
                    VrmDetails = table.Column<string>(type: "text", nullable: true),
                    RamSlots = table.Column<string>(type: "text", nullable: true),
                    SataPorts = table.Column<string>(type: "text", nullable: true),
                    M2Ports = table.Column<string>(type: "text", nullable: true),
                    ArgbHeaders = table.Column<string>(type: "text", nullable: true),
                    FanHeaders = table.Column<string>(type: "text", nullable: true),
                    Format = table.Column<string>(type: "text", nullable: true),
                    RamMaxFreq = table.Column<string>(type: "text", nullable: true),
                    RamMaxAmount = table.Column<string>(type: "text", nullable: true),
                    Soundcard = table.Column<string>(type: "text", nullable: true),
                    EthernetSpeed = table.Column<string>(type: "text", nullable: true),
                    EthernetCard = table.Column<string>(type: "text", nullable: true),
                    DefaultGenSupport = table.Column<string>(type: "text", nullable: true),
                    UpdateGenSupport = table.Column<string>(type: "text", nullable: true),
                    EAN = table.Column<string>(type: "text", nullable: true),
                    ShortCode = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCode = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Warranty = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Morele_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_RefLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Xkom_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_RefLink = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mainboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ModuleHeight = table.Column<string>(type: "text", nullable: true),
                    Modules = table.Column<string>(type: "text", nullable: true),
                    MemPerModule = table.Column<string>(type: "text", nullable: true),
                    MemAmount = table.Column<string>(type: "text", nullable: true),
                    XmpFreq = table.Column<string>(type: "text", nullable: true),
                    XmpVoltage = table.Column<string>(type: "text", nullable: true),
                    XmpLatency = table.Column<string>(type: "text", nullable: true),
                    SpdFreq = table.Column<string>(type: "text", nullable: true),
                    SpdVoltage = table.Column<string>(type: "text", nullable: true),
                    Radiator = table.Column<bool>(type: "boolean", nullable: false),
                    RGB = table.Column<bool>(type: "boolean", nullable: false),
                    EAN = table.Column<string>(type: "text", nullable: true),
                    ShortCode = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCode = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Warranty = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Morele_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_RefLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Xkom_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_RefLink = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score_DesktopPerf = table.Column<string>(type: "text", nullable: true),
                    Score_GamingPerf = table.Column<string>(type: "text", nullable: true),
                    Score_ProPerf = table.Column<string>(type: "text", nullable: true),
                    Score_CinebenchSingle = table.Column<string>(type: "text", nullable: true),
                    Score_CinebenchMulti = table.Column<string>(type: "text", nullable: true),
                    CacheL1 = table.Column<string>(type: "text", nullable: true),
                    CacheL2 = table.Column<string>(type: "text", nullable: true),
                    CacheL3 = table.Column<string>(type: "text", nullable: true),
                    RamFreq = table.Column<string>(type: "text", nullable: true),
                    TDP = table.Column<string>(type: "text", nullable: true),
                    Cores = table.Column<string>(type: "text", nullable: true),
                    Threads = table.Column<string>(type: "text", nullable: true),
                    BaseFrequency = table.Column<string>(type: "text", nullable: true),
                    BoostFrequency = table.Column<string>(type: "text", nullable: true),
                    Architecture = table.Column<string>(type: "text", nullable: true),
                    Lithography = table.Column<string>(type: "text", nullable: true),
                    Socket = table.Column<string>(type: "text", nullable: true),
                    SocketGen = table.Column<string>(type: "text", nullable: true),
                    Unlocked = table.Column<bool>(type: "boolean", nullable: false),
                    IGPU = table.Column<string>(type: "text", nullable: true),
                    Cooler = table.Column<string>(type: "text", nullable: true),
                    EAN = table.Column<string>(type: "text", nullable: true),
                    ShortCode = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCode = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Warranty = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Morele_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_RefLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Xkom_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_RefLink = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolidStateDrives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Interface = table.Column<string>(type: "text", nullable: true),
                    Controller = table.Column<string>(type: "text", nullable: true),
                    MemoryType = table.Column<string>(type: "text", nullable: true),
                    SeqRead = table.Column<string>(type: "text", nullable: true),
                    SeqWrite = table.Column<string>(type: "text", nullable: true),
                    RandRead = table.Column<string>(type: "text", nullable: true),
                    RandWrite = table.Column<string>(type: "text", nullable: true),
                    ScoreOverall = table.Column<string>(type: "text", nullable: true),
                    ScoreSustained = table.Column<string>(type: "text", nullable: true),
                    Tbw = table.Column<string>(type: "text", nullable: true),
                    Radiator = table.Column<bool>(type: "boolean", nullable: false),
                    EAN = table.Column<string>(type: "text", nullable: true),
                    ShortCode = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCode = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Warranty = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Morele_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Morele_RefLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_isAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    Shop_Xkom_CleanLink = table.Column<string>(type: "text", nullable: true),
                    Shop_Xkom_RefLink = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolidStateDrives", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardDisks");

            migrationBuilder.DropTable(
                name: "Mainboards");

            migrationBuilder.DropTable(
                name: "Memories");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "SolidStateDrives");
        }
    }
}
