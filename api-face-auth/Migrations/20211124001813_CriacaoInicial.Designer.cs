﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_face_auth.DataSqlite;

namespace api_face_auth.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211124001813_CriacaoInicial")]
    partial class CriacaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("api_face_auth.DataSqlite.Entities.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("registerDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("surname")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("idUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api_face_auth.DataSqlite.Entities.UserFace", b =>
                {
                    b.Property<int>("idface")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("iduser")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("image")
                        .HasColumnType("BLOB");

                    b.HasKey("idface");

                    b.ToTable("UsersFace");
                });
#pragma warning restore 612, 618
        }
    }
}