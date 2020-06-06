﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vuttr.API.Data.Context;

namespace Vuttr.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Vuttr.API.Domain.Models.Tool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string[]>("Tags")
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Tools");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9dc18a59-c736-4697-ac1c-fdc380292053"),
                            CreatedAt = new DateTime(2020, 5, 31, 23, 7, 15, 942, DateTimeKind.Local).AddTicks(7840),
                            Description = "Database Tool",
                            Link = "http://postgres.com",
                            Tags = new[] { "db", "postgre", "sql" },
                            Title = "Postgre SQL",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("5654a6e9-cb18-43fa-a95c-c959b9277267"),
                            CreatedAt = new DateTime(2020, 5, 31, 23, 7, 15, 942, DateTimeKind.Local).AddTicks(9700),
                            Description = "Rest Client",
                            Link = "http://insomnia.com",
                            Tags = new[] { "http", "api", "rest" },
                            Title = "Insomnia",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}