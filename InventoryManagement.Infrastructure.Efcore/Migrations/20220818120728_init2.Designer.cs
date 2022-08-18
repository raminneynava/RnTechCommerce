﻿// <auto-generated />
using System;
using InventoryManagement.Infrastructure.Efcore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryManagement.Infrastructure.Efcore.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20220818120728_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InventoryManagement.Domain.InventoryAgg.Inventory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("InventoryManagement.Domain.InventoryAgg.InventoryOperation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<long>("CurrentCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("InventoryId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Operation")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OperationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OperatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("InventoryOperation");
                });

            modelBuilder.Entity("InventoryManagement.Domain.InventoryAgg.InventoryOperation", b =>
                {
                    b.HasOne("InventoryManagement.Domain.InventoryAgg.Inventory", "Inventory")
                        .WithMany("Operations")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("InventoryManagement.Domain.InventoryAgg.Inventory", b =>
                {
                    b.Navigation("Operations");
                });
#pragma warning restore 612, 618
        }
    }
}
