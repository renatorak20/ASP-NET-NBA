﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBA.DAL;

#nullable disable

namespace NBA.DAL.Migrations
{
    [DbContext(typeof(NBAManagerDbContext))]
    [Migration("20240606093746_Team2")]
    partial class Team2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NBA.Model.Coach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.HasIndex("TeamID");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("NBA.Model.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("NBA.Model.Player", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("PositionID")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.HasIndex("PositionID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("NBA.Model.PlayerAttachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PlayerID");

                    b.ToTable("PlayerAttachment");
                });

            modelBuilder.Entity("NBA.Model.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Point Guard (PG)"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Shooting Guard (SG)"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Small Forward (SF)"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Power Forward (PF)"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Center (C)"
                        });
                });

            modelBuilder.Entity("NBA.Model.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("NBA.Model.Coach", b =>
                {
                    b.HasOne("NBA.Model.Country", "Country")
                        .WithMany("Coaches")
                        .HasForeignKey("CountryID");

                    b.HasOne("NBA.Model.Team", "Team")
                        .WithMany("Coaches")
                        .HasForeignKey("TeamID");

                    b.Navigation("Country");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NBA.Model.Player", b =>
                {
                    b.HasOne("NBA.Model.Country", "Country")
                        .WithMany("Players")
                        .HasForeignKey("CountryID");

                    b.HasOne("NBA.Model.Position", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionID");

                    b.HasOne("NBA.Model.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID");

                    b.Navigation("Country");

                    b.Navigation("Position");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NBA.Model.PlayerAttachment", b =>
                {
                    b.HasOne("NBA.Model.Player", "Player")
                        .WithMany("Attachments")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("NBA.Model.Country", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("NBA.Model.Player", b =>
                {
                    b.Navigation("Attachments");
                });

            modelBuilder.Entity("NBA.Model.Position", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("NBA.Model.Team", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
