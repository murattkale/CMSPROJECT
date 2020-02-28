using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entity.Migrations
{
    public partial class db335 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    CityName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DersGrup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersGrup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(nullable: false),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    SubeId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    TownId = table.Column<int>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    FormType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HesapTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    GelirGiderTipi = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapTip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KiyafetTur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiyafetTur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NeredenDuydunuz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeredenDuydunuz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Okullar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    OkulTipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okullar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParaBirimi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    Kod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParaBirimi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ServiceName = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(maxLength: 500, nullable: false),
                    UrlTarget = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceConfig_ServiceConfig",
                        column: x => x.ParentId,
                        principalTable: "ServiceConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    SubeId = table.Column<int>(nullable: false),
                    Plaka = table.Column<string>(nullable: false),
                    Guzergah = table.Column<string>(nullable: false),
                    Kapasite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SozlesmeTur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    Kontroller = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SozlesmeTur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Tc = table.Column<string>(maxLength: 11, nullable: false),
                    Pass = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Mail1 = table.Column<string>(maxLength: 50, nullable: true),
                    Mail2 = table.Column<string>(maxLength: 50, nullable: true),
                    Phone1 = table.Column<string>(maxLength: 50, nullable: true),
                    Phone2 = table.Column<string>(maxLength: 50, nullable: true),
                    Phone3 = table.Column<string>(maxLength: 50, nullable: true),
                    Adress1 = table.Column<string>(maxLength: 1000, nullable: true),
                    Adress2 = table.Column<string>(maxLength: 1000, nullable: true),
                    BirdhDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserNo = table.Column<string>(maxLength: 50, nullable: true),
                    SexType = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    TownId = table.Column<int>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: true),
                    ProfilImage = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VeliDetay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    OgrenciDetayId = table.Column<int>(nullable: false),
                    YakinlikDerecesiId = table.Column<int>(nullable: false),
                    Iletisim = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeliDetay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdemeTip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    BankaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdemeTip_Banka",
                        column: x => x.BankaId,
                        principalTable: "Banka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    TownName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Town__CityId__1F2E9E6D",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    DersGrupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ders_DersGrup",
                        column: x => x.DersGrupId,
                        principalTable: "DersGrup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kiyafet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    KiyafetTurId = table.Column<int>(nullable: false),
                    Beden = table.Column<int>(nullable: false),
                    Stok = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiyafet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kiyafet_KiyafetTur",
                        column: x => x.KiyafetTurId,
                        principalTable: "KiyafetTur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciDetay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    NeredenDuydunuzId = table.Column<int>(nullable: true),
                    AileMedeniDurum = table.Column<bool>(nullable: false),
                    OzelHastalik = table.Column<string>(nullable: true),
                    SinifTekrar = table.Column<bool>(nullable: true),
                    OkullarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciDetay_NeredenDuydunuz",
                        column: x => x.NeredenDuydunuzId,
                        principalTable: "NeredenDuydunuz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciDetay_Okullar",
                        column: x => x.OkullarId,
                        principalTable: "Okullar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StartPageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Roles",
                        column: x => x.ParentId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_ServiceConfig",
                        column: x => x.StartPageId,
                        principalTable: "ServiceConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kurum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    TownId = table.Column<int>(nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    GoogleAnalytic = table.Column<string>(nullable: true),
                    Maps = table.Column<string>(nullable: true),
                    TicariUnvan = table.Column<string>(nullable: true),
                    VergiNo = table.Column<string>(nullable: true),
                    VergiDairesi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurum_Town",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kurum_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    KurumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brans_Kurum",
                        column: x => x.KurumId,
                        principalTable: "Kurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sezon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    KurumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sezon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sezon_Kurum",
                        column: x => x.KurumId,
                        principalTable: "Kurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sube",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    KurumId = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: true),
                    TownId = table.Column<int>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    GoogleAnalytic = table.Column<string>(nullable: true),
                    Maps = table.Column<string>(nullable: true),
                    TicariUnvan = table.Column<string>(nullable: true),
                    VergiNo = table.Column<string>(nullable: true),
                    VergiDairesi = table.Column<string>(nullable: true),
                    SozlesmeTaksitLimit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sube", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sube_Town",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sube_Kurum",
                        column: x => x.KurumId,
                        principalTable: "Kurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sube_City",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceConfigAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    ServiceConfigId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    PermissionId = table.Column<int>(nullable: true),
                    IsCreate = table.Column<bool>(nullable: true),
                    IsRead = table.Column<bool>(nullable: true),
                    IsUpdate = table.Column<bool>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    IsList = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceConfigAuth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceConfigAuth_Permissions",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceConfigAuth_Roles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceConfigAuth_ServiceConfig",
                        column: x => x.ServiceConfigId,
                        principalTable: "ServiceConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceConfigAuth_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DersBrans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    BransId = table.Column<int>(nullable: false),
                    DersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersBrans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DersBrans_Brans",
                        column: x => x.BransId,
                        principalTable: "Brans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DersBrans_Ders",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yayin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    BransId = table.Column<int>(nullable: true),
                    SinifSeviye = table.Column<int>(nullable: false),
                    DersId = table.Column<int>(nullable: false),
                    StokAdet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yayin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yayin_Brans",
                        column: x => x.BransId,
                        principalTable: "Brans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yayin_Ders",
                        column: x => x.DersId,
                        principalTable: "Ders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    KurumId = table.Column<int>(nullable: true),
                    SubeId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ContentPageType = table.Column<int>(nullable: false),
                    IsHeaderMenu = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsFooterMenu = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsSideMenu = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsHamburgerMenu = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    Content = table.Column<string>(nullable: true),
                    ContentShort = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    BannerText = table.Column<string>(nullable: true),
                    BannerImage = table.Column<string>(nullable: true),
                    DefaultImage = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    ButtonText1 = table.Column<string>(nullable: true),
                    ButtonText1Link = table.Column<string>(nullable: true),
                    ButtonText2 = table.Column<string>(nullable: true),
                    ButtonText2Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentPage_Kurum",
                        column: x => x.KurumId,
                        principalTable: "Kurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentPage_Sube",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Derslik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    SubeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derslik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Derslik_Sube",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kasa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: true),
                    ParaBirimId = table.Column<int>(nullable: false),
                    BankaId = table.Column<int>(nullable: true),
                    UstKasaId = table.Column<int>(nullable: true),
                    GelenTotal = table.Column<double>(nullable: true),
                    CekilenTotal = table.Column<double>(nullable: true),
                    Total = table.Column<double>(nullable: true),
                    KurumId = table.Column<int>(nullable: true),
                    SubeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kasa_Banka",
                        column: x => x.BankaId,
                        principalTable: "Banka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kasa_Kurum",
                        column: x => x.KurumId,
                        principalTable: "Kurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kasa_ParaBirimi",
                        column: x => x.ParaBirimId,
                        principalTable: "ParaBirimi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kasa_Sube",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kasa_Kasa",
                        column: x => x.UstKasaId,
                        principalTable: "Kasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciSozlesme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    OgrenciDetayId = table.Column<int>(nullable: false),
                    SozlesmeTuruId = table.Column<int>(nullable: false),
                    ReferansAdSoyad = table.Column<string>(nullable: true),
                    SubeId = table.Column<int>(nullable: true),
                    GorusenPersonelId = table.Column<int>(nullable: true),
                    KurumaGetirenPersonelId = table.Column<int>(nullable: true),
                    SezonId = table.Column<int>(nullable: false),
                    ServisId = table.Column<int>(nullable: true),
                    FinansorId = table.Column<int>(nullable: false),
                    FaturaAd = table.Column<string>(nullable: true),
                    FaturaSoyad = table.Column<string>(nullable: true),
                    VergiNo = table.Column<string>(nullable: true),
                    VergiDairesi = table.Column<string>(nullable: true),
                    EgitimTutar = table.Column<double>(nullable: true),
                    ServisTutar = table.Column<double>(nullable: true),
                    YayinTutar = table.Column<double>(nullable: true),
                    ToplamTutar = table.Column<double>(nullable: true),
                    PesinatTutari = table.Column<double>(nullable: true),
                    TaksitAdet = table.Column<int>(nullable: true),
                    TaksitBaslangic = table.Column<DateTime>(type: "datetime", nullable: true),
                    DersAdedi = table.Column<int>(nullable: true),
                    DersBirimTutar = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSozlesme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_VeliDetay",
                        column: x => x.FinansorId,
                        principalTable: "VeliDetay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_Users",
                        column: x => x.GorusenPersonelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_Users1",
                        column: x => x.KurumaGetirenPersonelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_OgrenciDetay",
                        column: x => x.OgrenciDetayId,
                        principalTable: "OgrenciDetay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_Servis",
                        column: x => x.ServisId,
                        principalTable: "Servis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_Sezon",
                        column: x => x.SezonId,
                        principalTable: "Sezon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_SozlesmeTur",
                        column: x => x.SozlesmeTuruId,
                        principalTable: "SozlesmeTur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesme_Sube",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    SubeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seans_Sube",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sozlesme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    Metin = table.Column<string>(type: "text", nullable: false),
                    SubeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sozlesme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sozlesme_Sube",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Types = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Guid = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    data_class = table.Column<string>(nullable: true),
                    dataid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Documents",
                        column: x => x.dataid,
                        principalTable: "ContentPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hesap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    HesapTipId = table.Column<int>(nullable: false),
                    ilgiliKasaId = table.Column<int>(nullable: false),
                    aliciKasaId = table.Column<int>(nullable: true),
                    OdemeTipId = table.Column<int>(nullable: false),
                    Tutar = table.Column<double>(nullable: false),
                    Aciklama = table.Column<string>(nullable: true),
                    OnayTip = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hesap_Kasa1",
                        column: x => x.aliciKasaId,
                        principalTable: "Kasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hesap_HesapTip",
                        column: x => x.HesapTipId,
                        principalTable: "HesapTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hesap_Kasa",
                        column: x => x.ilgiliKasaId,
                        principalTable: "Kasa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hesap_OdemeTip",
                        column: x => x.OdemeTipId,
                        principalTable: "OdemeTip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciSozlesmeKiyafet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    OgrenciSozlesmeId = table.Column<int>(nullable: false),
                    KiyafetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSozlesmeKiyafet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesmeKiyafet_Kiyafet",
                        column: x => x.KiyafetId,
                        principalTable: "Kiyafet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesmeKiyafet_OgrenciSozlesme",
                        column: x => x.OgrenciSozlesmeId,
                        principalTable: "OgrenciSozlesme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciSozlesmeOdemeTablosu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    OgrenciSozlesmeId = table.Column<int>(nullable: false),
                    Tutar = table.Column<double>(nullable: false),
                    PesinatTarih = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSozlesmeOdemeTablosu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesmeOdemeTablosu_OgrenciSozlesme",
                        column: x => x.OgrenciSozlesmeId,
                        principalTable: "OgrenciSozlesme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciSozlesmeYayin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    OgrenciSozlesmeId = table.Column<int>(nullable: false),
                    YayinId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSozlesmeYayin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesmeYayin_OgrenciSozlesme",
                        column: x => x.OgrenciSozlesmeId,
                        principalTable: "OgrenciSozlesme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSozlesmeYayin_Yayin",
                        column: x => x.YayinId,
                        principalTable: "Yayin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinif",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    Ad = table.Column<string>(nullable: false),
                    SubeId = table.Column<int>(nullable: false),
                    Tur = table.Column<int>(nullable: true),
                    Seviye = table.Column<int>(nullable: true),
                    SeansId = table.Column<int>(nullable: true),
                    DerslikId = table.Column<int>(nullable: true),
                    SorumluKisiId = table.Column<int>(nullable: true),
                    ToplamDersSaati = table.Column<int>(nullable: false),
                    Kapasite = table.Column<int>(nullable: false),
                    KayitUcreti = table.Column<double>(nullable: false),
                    EgitimSuresi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinif_Derslik",
                        column: x => x.DerslikId,
                        principalTable: "Derslik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sinif_Seans",
                        column: x => x.SeansId,
                        principalTable: "Seans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sinif_Sube",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdemeDetay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    HesapId = table.Column<int>(nullable: false),
                    BankaSubesi = table.Column<string>(nullable: true),
                    BankaHesapNo = table.Column<string>(nullable: true),
                    Borclu = table.Column<string>(nullable: true),
                    CekFazlasi = table.Column<string>(nullable: true),
                    VadeTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    CekNo = table.Column<string>(nullable: true),
                    EnSonCiroEden = table.Column<string>(nullable: true),
                    EkBilgi = table.Column<string>(nullable: true),
                    KullanilanKartTuru = table.Column<string>(nullable: true),
                    SlipOnayKodu = table.Column<string>(nullable: true),
                    TaksitSayisi = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdemeDetay_Hesap",
                        column: x => x.HesapId,
                        principalTable: "Hesap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SinifOgrenci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreaDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreaUser = table.Column<int>(nullable: false),
                    ModUser = table.Column<int>(nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderNo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsStatus = table.Column<int>(nullable: true),
                    SinifId = table.Column<int>(nullable: false),
                    OgrenciId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinifOgrenci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SinifOgrenci_Users",
                        column: x => x.OgrenciId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SinifOgrenci_Sinif",
                        column: x => x.SinifId,
                        principalTable: "Sinif",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brans_KurumId",
                table: "Brans",
                column: "KurumId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPage_KurumId",
                table: "ContentPage",
                column: "KurumId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentPage_SubeId",
                table: "ContentPage",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ders_DersGrupId",
                table: "Ders",
                column: "DersGrupId");

            migrationBuilder.CreateIndex(
                name: "IX_DersBrans_BransId",
                table: "DersBrans",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_DersBrans_DersId",
                table: "DersBrans",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_Derslik_SubeId",
                table: "Derslik",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_dataid",
                table: "Documents",
                column: "dataid");

            migrationBuilder.CreateIndex(
                name: "IX_Hesap_aliciKasaId",
                table: "Hesap",
                column: "aliciKasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesap_HesapTipId",
                table: "Hesap",
                column: "HesapTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesap_ilgiliKasaId",
                table: "Hesap",
                column: "ilgiliKasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesap_OdemeTipId",
                table: "Hesap",
                column: "OdemeTipId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_BankaId",
                table: "Kasa",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_KurumId",
                table: "Kasa",
                column: "KurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_ParaBirimId",
                table: "Kasa",
                column: "ParaBirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_SubeId",
                table: "Kasa",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kasa_UstKasaId",
                table: "Kasa",
                column: "UstKasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kiyafet_KiyafetTurId",
                table: "Kiyafet",
                column: "KiyafetTurId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurum_TownId",
                table: "Kurum",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurum_CityId",
                table: "Kurum",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OdemeDetay_HesapId",
                table: "OdemeDetay",
                column: "HesapId");

            migrationBuilder.CreateIndex(
                name: "IX_OdemeTip_BankaId",
                table: "OdemeTip",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDetay_NeredenDuydunuzId",
                table: "OgrenciDetay",
                column: "NeredenDuydunuzId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDetay_OkullarId",
                table: "OgrenciDetay",
                column: "OkullarId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_FinansorId",
                table: "OgrenciSozlesme",
                column: "FinansorId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_GorusenPersonelId",
                table: "OgrenciSozlesme",
                column: "GorusenPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_KurumaGetirenPersonelId",
                table: "OgrenciSozlesme",
                column: "KurumaGetirenPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_OgrenciDetayId",
                table: "OgrenciSozlesme",
                column: "OgrenciDetayId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_ServisId",
                table: "OgrenciSozlesme",
                column: "ServisId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_SezonId",
                table: "OgrenciSozlesme",
                column: "SezonId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_SozlesmeTuruId",
                table: "OgrenciSozlesme",
                column: "SozlesmeTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesme_SubeId",
                table: "OgrenciSozlesme",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesmeKiyafet_KiyafetId",
                table: "OgrenciSozlesmeKiyafet",
                column: "KiyafetId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesmeKiyafet_OgrenciSozlesmeId",
                table: "OgrenciSozlesmeKiyafet",
                column: "OgrenciSozlesmeId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesmeOdemeTablosu_OgrenciSozlesmeId",
                table: "OgrenciSozlesmeOdemeTablosu",
                column: "OgrenciSozlesmeId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesmeYayin_OgrenciSozlesmeId",
                table: "OgrenciSozlesmeYayin",
                column: "OgrenciSozlesmeId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSozlesmeYayin_YayinId",
                table: "OgrenciSozlesmeYayin",
                column: "YayinId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ParentId",
                table: "Roles",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StartPageId",
                table: "Roles",
                column: "StartPageId");

            migrationBuilder.CreateIndex(
                name: "IX_Seans_SubeId",
                table: "Seans",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfig_ParentId",
                table: "ServiceConfig",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfigAuth_PermissionId",
                table: "ServiceConfigAuth",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfigAuth_RoleId",
                table: "ServiceConfigAuth",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfigAuth_ServiceConfigId",
                table: "ServiceConfigAuth",
                column: "ServiceConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfigAuth_UserId",
                table: "ServiceConfigAuth",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sezon_KurumId",
                table: "Sezon",
                column: "KurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinif_DerslikId",
                table: "Sinif",
                column: "DerslikId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinif_SeansId",
                table: "Sinif",
                column: "SeansId");

            migrationBuilder.CreateIndex(
                name: "IX_Sinif_SubeId",
                table: "Sinif",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_SinifOgrenci_OgrenciId",
                table: "SinifOgrenci",
                column: "OgrenciId");

            migrationBuilder.CreateIndex(
                name: "IX_SinifOgrenci_SinifId",
                table: "SinifOgrenci",
                column: "SinifId");

            migrationBuilder.CreateIndex(
                name: "IX_Sozlesme_SubeId",
                table: "Sozlesme",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sube_TownId",
                table: "Sube",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Sube_KurumId",
                table: "Sube",
                column: "KurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Sube_CityId",
                table: "Sube",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_CityId",
                table: "Town",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Yayin_BransId",
                table: "Yayin",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_Yayin_DersId",
                table: "Yayin",
                column: "DersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersBrans");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Formlar");

            migrationBuilder.DropTable(
                name: "OdemeDetay");

            migrationBuilder.DropTable(
                name: "OgrenciSozlesmeKiyafet");

            migrationBuilder.DropTable(
                name: "OgrenciSozlesmeOdemeTablosu");

            migrationBuilder.DropTable(
                name: "OgrenciSozlesmeYayin");

            migrationBuilder.DropTable(
                name: "ServiceConfigAuth");

            migrationBuilder.DropTable(
                name: "SinifOgrenci");

            migrationBuilder.DropTable(
                name: "Sozlesme");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ContentPage");

            migrationBuilder.DropTable(
                name: "Hesap");

            migrationBuilder.DropTable(
                name: "Kiyafet");

            migrationBuilder.DropTable(
                name: "OgrenciSozlesme");

            migrationBuilder.DropTable(
                name: "Yayin");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Sinif");

            migrationBuilder.DropTable(
                name: "Kasa");

            migrationBuilder.DropTable(
                name: "HesapTip");

            migrationBuilder.DropTable(
                name: "OdemeTip");

            migrationBuilder.DropTable(
                name: "KiyafetTur");

            migrationBuilder.DropTable(
                name: "VeliDetay");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OgrenciDetay");

            migrationBuilder.DropTable(
                name: "Servis");

            migrationBuilder.DropTable(
                name: "Sezon");

            migrationBuilder.DropTable(
                name: "SozlesmeTur");

            migrationBuilder.DropTable(
                name: "Brans");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Derslik");

            migrationBuilder.DropTable(
                name: "Seans");

            migrationBuilder.DropTable(
                name: "ParaBirimi");

            migrationBuilder.DropTable(
                name: "Banka");

            migrationBuilder.DropTable(
                name: "NeredenDuydunuz");

            migrationBuilder.DropTable(
                name: "Okullar");

            migrationBuilder.DropTable(
                name: "DersGrup");

            migrationBuilder.DropTable(
                name: "ServiceConfig");

            migrationBuilder.DropTable(
                name: "Sube");

            migrationBuilder.DropTable(
                name: "Kurum");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
