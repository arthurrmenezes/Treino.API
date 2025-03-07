﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TreinoAPI.DataBase;

#nullable disable

namespace Treino.API.Migrations
{
    [DbContext(typeof(TreinoContext))]
    partial class TreinoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Treino.API.Models.TreinoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Distancia")
                        .HasColumnType("double precision");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Tempo")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.ToTable("Treinos");
                });
#pragma warning restore 612, 618
        }
    }
}
