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
    [Migration("20211019172354_AddedUserFace")]
    partial class AddedUserFace
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("api_face_auth.DataSqlite.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("usuario")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

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
