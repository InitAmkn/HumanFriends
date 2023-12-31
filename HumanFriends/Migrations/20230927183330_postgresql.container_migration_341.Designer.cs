﻿// <auto-generated />
using System;
using HumanFriends.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HumanFriends.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230927183330_postgresql.container_migration_341")]
    partial class postgresqlcontainer_migration_341
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HumanFriends.Entity.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeAnimalID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("TypeAnimalID");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("HumanFriends.Entity.ApplicabilityAnimal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ApplicabilityAnimal");
                });

            modelBuilder.Entity("HumanFriends.Entity.TypeAnimal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("ApplicabilityAnimalID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ApplicabilityAnimalID");

                    b.ToTable("TypeAnimal");
                });

            modelBuilder.Entity("HumanFriends.Entity.Animal", b =>
                {
                    b.HasOne("HumanFriends.Entity.TypeAnimal", "TypeAnimal")
                        .WithMany()
                        .HasForeignKey("TypeAnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeAnimal");
                });

            modelBuilder.Entity("HumanFriends.Entity.TypeAnimal", b =>
                {
                    b.HasOne("HumanFriends.Entity.ApplicabilityAnimal", "ApplicabilityAnimal")
                        .WithMany()
                        .HasForeignKey("ApplicabilityAnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicabilityAnimal");
                });
#pragma warning restore 612, 618
        }
    }
}
