﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DynamicSiteEntity.Migrations
{
    [DbContext(typeof(CMSDBContext))]
    [Migration("20200315230418_db3455363sdfsd")]
    partial class db3455363sdfsd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ContentPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BannerImage")
                        .HasColumnType("text");

                    b.Property<string>("BannerText")
                        .HasColumnType("text");

                    b.Property<string>("ButtonText1")
                        .HasColumnType("text");

                    b.Property<string>("ButtonText1Link")
                        .HasColumnType("text");

                    b.Property<string>("ButtonText2")
                        .HasColumnType("text");

                    b.Property<string>("ButtonText2Link")
                        .HasColumnType("text");

                    b.Property<string>("ContentData")
                        .HasColumnType("text");

                    b.Property<int?>("ContentOrderNo")
                        .HasColumnType("integer");

                    b.Property<int?>("ContentPageId")
                        .HasColumnType("integer");

                    b.Property<int>("ContentPageType")
                        .HasColumnType("integer");

                    b.Property<string>("ContentShort")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool?>("IsFooterMenu")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsForm")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsGallery")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsHamburgerMenu")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsHeaderMenu")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsMap")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsSideMenu")
                        .HasColumnType("boolean");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("text");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<string>("ResimLink")
                        .HasColumnType("text");

                    b.Property<string>("ThumbImage")
                        .HasColumnType("text");

                    b.Property<string>("VideoLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContentPageId");

                    b.ToTable("ContentPage");
                });

            modelBuilder.Entity("Documents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Alt")
                        .HasColumnType("text");

                    b.Property<int>("ContentPageId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<string>("Guid")
                        .HasColumnType("text");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Types")
                        .HasColumnType("text");

                    b.Property<string>("data_class")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContentPageId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Formlar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Adres")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<int?>("FormType")
                        .HasColumnType("integer");

                    b.Property<string>("Icerik")
                        .HasColumnType("text");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Formlar");
                });

            modelBuilder.Entity("Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleParentId")
                        .HasColumnType("integer");

                    b.Property<int?>("ServiceConfigId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleParentId");

                    b.HasIndex("ServiceConfigId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ServiceConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("ServiceName")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<string>("UrlTarget")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ServiceConfig");
                });

            modelBuilder.Entity("ServiceConfigAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsCreate")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool?>("IsList")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsUpdate")
                        .HasColumnType("boolean");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<int?>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceConfigId")
                        .HasColumnType("integer");

                    b.Property<int?>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.HasIndex("ServiceConfigId");

                    b.HasIndex("UsersId");

                    b.ToTable("ServiceConfigAuth");
                });

            modelBuilder.Entity("SiteConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BaseUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BodyScript")
                        .HasColumnType("text");

                    b.Property<string>("Copyright")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<string>("DefaultImage")
                        .HasColumnType("text");

                    b.Property<string>("FooterScript")
                        .HasColumnType("text");

                    b.Property<string>("FooterStyle")
                        .HasColumnType("text");

                    b.Property<string>("HeadScript")
                        .HasColumnType("text");

                    b.Property<string>("HeadStyle")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<string>("JokerPass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Map")
                        .HasColumnType("text");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("text");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<string>("StartAction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StartPage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("layoutID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("layoutUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("layoutUrlBase")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SiteConfig");
                });

            modelBuilder.Entity("Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<string>("TownName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Town");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress1")
                        .HasColumnType("text");

                    b.Property<string>("Adress2")
                        .HasColumnType("text");

                    b.Property<DateTime>("BirdhDay")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("CityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<string>("Mail1")
                        .HasColumnType("text");

                    b.Property<string>("Mail2")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone1")
                        .HasColumnType("text");

                    b.Property<string>("Phone2")
                        .HasColumnType("text");

                    b.Property<string>("Phone3")
                        .HasColumnType("text");

                    b.Property<string>("ProfilImage")
                        .HasColumnType("text");

                    b.Property<string>("SexType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tc")
                        .IsRequired()
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.Property<int?>("TownId")
                        .HasColumnType("integer");

                    b.Property<string>("UserNo")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("TownId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreaDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreaUser")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IsDeleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer");

                    b.Property<int?>("OrderNo")
                        .HasColumnType("integer");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("ContentPage", b =>
                {
                    b.HasOne("ContentPage", "Parent")
                        .WithMany("ContentPageChilds")
                        .HasForeignKey("ContentPageId");
                });

            modelBuilder.Entity("Documents", b =>
                {
                    b.HasOne("ContentPage", "ContentPage")
                        .WithMany("Documents")
                        .HasForeignKey("ContentPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Permission", b =>
                {
                    b.HasOne("Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.HasOne("Role", "RoleParent")
                        .WithMany("ParentRoles")
                        .HasForeignKey("RoleParentId");

                    b.HasOne("ServiceConfig", null)
                        .WithMany("Role")
                        .HasForeignKey("ServiceConfigId");
                });

            modelBuilder.Entity("ServiceConfig", b =>
                {
                    b.HasOne("ServiceConfig", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ServiceConfigAuth", b =>
                {
                    b.HasOne("Permission", "Permission")
                        .WithMany("ServiceConfigAuth")
                        .HasForeignKey("PermissionId");

                    b.HasOne("Role", "Role")
                        .WithMany("ServiceConfigAuth")
                        .HasForeignKey("RoleId");

                    b.HasOne("ServiceConfig", "ServiceConfig")
                        .WithMany("ServiceConfigAuth")
                        .HasForeignKey("ServiceConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "Users")
                        .WithMany("ServiceConfigAuth")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("Town", b =>
                {
                    b.HasOne("City", "City")
                        .WithMany("Town")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
