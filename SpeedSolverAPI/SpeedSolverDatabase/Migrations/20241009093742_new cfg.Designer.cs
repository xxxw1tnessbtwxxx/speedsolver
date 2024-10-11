﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SpeedSolverDatabase;

#nullable disable

namespace SpeedSolverDatabase.Migrations
{
    [DbContext(typeof(SpeedContext))]
    [Migration("20241009093742_new cfg")]
    partial class newcfg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SpeedSolverDatabase.Models.Objective", b =>
                {
                    b.Property<int>("ObjectiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ObjectiveId"));

                    b.Property<string>("ObjectiveDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ObjectiveTitle")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.HasKey("ObjectiveId");

                    b.HasIndex("ProjectId");

                    b.ToTable("objectives", (string)null);
                });

            modelBuilder.Entity("SpeedSolverDatabase.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProjectId");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("SpeedSolverDatabase.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeamId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("TeamDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TeamId");

                    b.HasIndex("CreatorId");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("SpeedSolverDatabase.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("SpeedSolverDatabase.Models.Objective", b =>
                {
                    b.HasOne("SpeedSolverDatabase.Models.Project", "Project")
                        .WithMany("Objectives")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SpeedSolverDatabase.Models.Team", b =>
                {
                    b.HasOne("SpeedSolverDatabase.Models.User", "Creator")
                        .WithMany("Teams")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("SpeedSolverDatabase.Models.Project", b =>
                {
                    b.Navigation("Objectives");
                });

            modelBuilder.Entity("SpeedSolverDatabase.Models.User", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
