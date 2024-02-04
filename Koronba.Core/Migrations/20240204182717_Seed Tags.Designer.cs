﻿// <auto-generated />
using System;
using Koronba.Core.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Koronba.Core.Migrations
{
    [DbContext(typeof(KoronbaDbContext))]
    [Migration("20240204182717_Seed Tags")]
    partial class SeedTags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("FlashTag", b =>
                {
                    b.Property<int>("FlashesId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("TEXT");

                    b.HasKey("FlashesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("FlashTag");
                });

            modelBuilder.Entity("Koronba.Core.Models.Flash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastSeenAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Flashes");
                });

            modelBuilder.Entity("Koronba.Core.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d3368962-80ec-4ad8-9974-7bacfcc08237"),
                            Name = "Aww"
                        },
                        new
                        {
                            Id = new Guid("185eb500-d530-49d9-b7e2-27da68420fcd"),
                            Name = "Lol"
                        },
                        new
                        {
                            Id = new Guid("00e0107c-c103-4989-abe4-c638666bf661"),
                            Name = "Wtf"
                        },
                        new
                        {
                            Id = new Guid("bfccb5fa-f397-43f5-9b97-e462ee8114d4"),
                            Name = "Classic"
                        },
                        new
                        {
                            Id = new Guid("48030715-6457-4e8b-a03d-a0bd23e2fb6f"),
                            Name = "Cool"
                        },
                        new
                        {
                            Id = new Guid("8b8ea90b-e979-4ebb-897e-6f50ad9e27cd"),
                            Name = "Loop"
                        },
                        new
                        {
                            Id = new Guid("697c4da3-a1da-4007-9c20-a83677141ff5"),
                            Name = "Game"
                        },
                        new
                        {
                            Id = new Guid("a64e3efd-b3d8-4fdc-8f5f-8ca745dd9b96"),
                            Name = "Misc"
                        });
                });

            modelBuilder.Entity("FlashTag", b =>
                {
                    b.HasOne("Koronba.Core.Models.Flash", null)
                        .WithMany()
                        .HasForeignKey("FlashesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Koronba.Core.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Koronba.Core.Models.Flash", b =>
                {
                    b.OwnsOne("Koronba.Core.Models.FlashMeta", "Metadata", b1 =>
                        {
                            b1.Property<int>("FlashId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("FileSize")
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT");

                            b1.HasKey("FlashId");

                            b1.ToTable("Flashes");

                            b1.WithOwner()
                                .HasForeignKey("FlashId");
                        });

                    b.OwnsMany("Koronba.Core.Models.FlashName", "KnownNames", b1 =>
                        {
                            b1.Property<int>("FlashId")
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<int>("Seen")
                                .HasColumnType("INTEGER");

                            b1.HasKey("FlashId", "Id");

                            b1.ToTable("FlashName");

                            b1.WithOwner()
                                .HasForeignKey("FlashId");
                        });

                    b.Navigation("KnownNames");

                    b.Navigation("Metadata")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
