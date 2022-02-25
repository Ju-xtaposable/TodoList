﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Models;

#nullable disable

namespace TodoList.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20220224212236_creation")]
    partial class creation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("BadgeTache", b =>
                {
                    b.Property<int>("BadgesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TachesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BadgesId", "TachesId");

                    b.HasIndex("TachesId");

                    b.ToTable("TacheBadge", (string)null);
                });

            modelBuilder.Entity("TodoList.Models.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Badge");
                });

            modelBuilder.Entity("TodoList.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxTaches")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("TodoList.Models.Tache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Archivée")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategorieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCible")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Tache");
                });

            modelBuilder.Entity("BadgeTache", b =>
                {
                    b.HasOne("TodoList.Models.Badge", null)
                        .WithMany()
                        .HasForeignKey("BadgesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoList.Models.Tache", null)
                        .WithMany()
                        .HasForeignKey("TachesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TodoList.Models.Tache", b =>
                {
                    b.HasOne("TodoList.Models.Categorie", "Categorie")
                        .WithMany("Taches")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("TodoList.Models.Categorie", b =>
                {
                    b.Navigation("Taches");
                });
#pragma warning restore 612, 618
        }
    }
}