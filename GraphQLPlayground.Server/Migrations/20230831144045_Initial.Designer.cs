﻿// <auto-generated />
using System;
using GraphQLPlayground.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLPlayground.Server.Migrations
{
    [DbContext(typeof(OrdersDbContext))]
    [Migration("20230831144045_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraphQLPlayground.Server.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"),
                            FirstName = "Jane",
                            LastName = "Doe",
                            Notes = "Customer Jane Doe"
                        },
                        new
                        {
                            Id = new Guid("9c0373db-994e-44b5-9ed0-d18936ecfe19"),
                            FirstName = "John",
                            LastName = "Doe",
                            Notes = "Customer John Doe"
                        },
                        new
                        {
                            Id = new Guid("aeab639a-efd1-4bf2-81d8-0c068f7cc692"),
                            FirstName = "James",
                            LastName = "Smith",
                            Notes = "Customer James Smith"
                        });
                });

            modelBuilder.Entity("GraphQLPlayground.Server.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreaatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a313c969-3fe7-41e9-8563-9e660d5038e8"),
                            CreaatedAt = new DateTime(2023, 8, 30, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6245),
                            CustomerId = new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"),
                            Status = "Placed"
                        },
                        new
                        {
                            Id = new Guid("8a9be312-c805-49bb-b65e-96e5bc561768"),
                            CreaatedAt = new DateTime(2023, 8, 29, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6267),
                            CustomerId = new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"),
                            Status = "Shipped"
                        },
                        new
                        {
                            Id = new Guid("026f0bd5-dfe6-4b77-942c-9ab5aabbd4f6"),
                            CreaatedAt = new DateTime(2023, 8, 28, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6268),
                            CustomerId = new Guid("e379e717-a2f0-4e48-be00-7279aa0a0b6a"),
                            Status = "Delivered"
                        },
                        new
                        {
                            Id = new Guid("3a23cb7b-9385-48e6-b9cf-c80ec74a831a"),
                            CreaatedAt = new DateTime(2023, 8, 30, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6270),
                            CustomerId = new Guid("9c0373db-994e-44b5-9ed0-d18936ecfe19"),
                            Status = "Placed."
                        },
                        new
                        {
                            Id = new Guid("48953dff-8b4f-4164-8a05-ff54412d4fda"),
                            CreaatedAt = new DateTime(2023, 8, 30, 14, 40, 44, 972, DateTimeKind.Utc).AddTicks(6271),
                            CustomerId = new Guid("aeab639a-efd1-4bf2-81d8-0c068f7cc692"),
                            Status = "Delivered"
                        });
                });

            modelBuilder.Entity("GraphQLPlayground.Server.Models.Order", b =>
                {
                    b.HasOne("GraphQLPlayground.Server.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("GraphQLPlayground.Server.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
