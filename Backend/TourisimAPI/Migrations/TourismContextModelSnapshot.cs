﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourismAPI.Models.Context;

#nullable disable

namespace TourismAPI.Migrations
{
    [DbContext(typeof(TourismContext))]
    partial class TourismContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TourismAPI.Models.Exclusion", b =>
                {
                    b.Property<int>("ExclusionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExclusionId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExclusionId");

                    b.ToTable("Exclusions");
                });

            modelBuilder.Entity("TourismAPI.Models.Inclusion", b =>
                {
                    b.Property<int>("InclusionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InclusionId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InclusionId");

                    b.ToTable("Inclusions");
                });

            modelBuilder.Entity("TourismAPI.Models.Tour", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourId"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TourType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TravelAgentId")
                        .HasColumnType("int");

                    b.HasKey("TourId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TourismAPI.Models.TourDates", b =>
                {
                    b.Property<int>("DateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateId"), 1L, 1);

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("DateId");

                    b.HasIndex("TourId");

                    b.ToTable("TourDates");
                });

            modelBuilder.Entity("TourismAPI.Models.TourExclusion", b =>
                {
                    b.Property<int>("TourExclusionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourExclusionId"), 1L, 1);

                    b.Property<int>("ExclusionId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("TourExclusionId");

                    b.HasIndex("ExclusionId");

                    b.HasIndex("TourId");

                    b.ToTable("TourExclusions");
                });

            modelBuilder.Entity("TourismAPI.Models.TourInclusion", b =>
                {
                    b.Property<int>("TourInclusionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourInclusionId"), 1L, 1);

                    b.Property<int>("InclusionId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("TourInclusionId");

                    b.HasIndex("InclusionId");

                    b.HasIndex("TourId");

                    b.ToTable("TourInclusions");
                });

            modelBuilder.Entity("TourismAPI.Models.TourDates", b =>
                {
                    b.HasOne("TourismAPI.Models.Tour", "Tour")
                        .WithMany("TourDates")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourismAPI.Models.TourExclusion", b =>
                {
                    b.HasOne("TourismAPI.Models.Exclusion", "Exclusion")
                        .WithMany()
                        .HasForeignKey("ExclusionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourismAPI.Models.Tour", "Tour")
                        .WithMany("TourExclusions")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exclusion");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourismAPI.Models.TourInclusion", b =>
                {
                    b.HasOne("TourismAPI.Models.Inclusion", "Inclusion")
                        .WithMany()
                        .HasForeignKey("InclusionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourismAPI.Models.Tour", "Tour")
                        .WithMany("TourInclusions")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inclusion");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourismAPI.Models.Tour", b =>
                {
                    b.Navigation("TourDates");

                    b.Navigation("TourExclusions");

                    b.Navigation("TourInclusions");
                });
#pragma warning restore 612, 618
        }
    }
}
