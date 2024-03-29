﻿// <auto-generated />
using System;
using MegaDeskRazorPages.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskRazorPages.Migrations
{
    [DbContext(typeof(MegaDeskRazorPagesContext))]
    partial class MegaDeskRazorPagesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskRazorPages.Models.Desk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("depth")
                        .HasColumnType("int");

                    b.Property<int>("drawers")
                        .HasColumnType("int");

                    b.Property<string>("surfaceMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Desk");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Desk");
                });

            modelBuilder.Entity("MegaDeskRazorPages.Models.DeskQuote", b =>
                {
                    b.HasBaseType("MegaDeskRazorPages.Models.Desk");

                    b.Property<string>("customerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("quoteDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("quoteTotal")
                        .HasColumnType("int");

                    b.Property<int>("rushDays")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DeskQuote");
                });
#pragma warning restore 612, 618
        }
    }
}
