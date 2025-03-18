﻿// <auto-generated />
using System;
using MetekLisansApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MetekLisansApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250317100345_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("MetekLisansApp.Models.Ekran", b =>
                {
                    b.Property<int>("EkranId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EkranAd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EkranNo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MenuId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("EkranId");

                    b.HasIndex("MenuId");

                    b.ToTable("Ekranlar");
                });

            modelBuilder.Entity("MetekLisansApp.Models.Firma", b =>
                {
                    b.Property<int>("FirmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirmaAd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirmaKod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FirmaId");

                    b.ToTable("Firmalar");
                });

            modelBuilder.Entity("MetekLisansApp.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("MetekLisansApp.Models.Lisans", b =>
                {
                    b.Property<int>("LisansId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirmaAd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LisansKodu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LisansVerilmeTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("OlusturanUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LisansId");

                    b.ToTable("Lisanslar");
                });

            modelBuilder.Entity("MetekLisansApp.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MenuAd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SiraNo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("MenuId");

                    b.ToTable("Menuler");
                });

            modelBuilder.Entity("MetekLisansApp.Models.Ekran", b =>
                {
                    b.HasOne("MetekLisansApp.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}
