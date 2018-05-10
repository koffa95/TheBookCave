﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using TheBookCave.Data;

namespace TheBookCave.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheBookCave.Data.EntityModels.Author", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<bool>("alive");

                    b.Property<string>("countryOfBirth");

                    b.Property<string>("image");

                    b.Property<string>("name");

                    b.Property<string>("shortDescription");

                    b.Property<int>("yearOfBirth");

                    b.HasKey("id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("TheBookCave.Data.EntityModels.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("author");

                    b.Property<int>("authorId");

                    b.Property<string>("genre");

                    b.Property<string>("image");

                    b.Property<string>("language");

                    b.Property<string>("originalLanguage");

                    b.Property<int>("pages");

                    b.Property<int>("price");

                    b.Property<string>("publisher");

                    b.Property<int>("releaseYear");

                    b.Property<string>("shortDescription");

                    b.Property<string>("title");

                    b.Property<string>("translator");

                    b.HasKey("id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("TheBookCave.Data.EntityModels.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("bookId");

                    b.HasKey("id");

                    b.HasIndex("bookId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("TheBookCave.Data.EntityModels.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("password");

                    b.Property<bool>("staff");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("TheBookCave.Data.EntityModels.Customer", b =>
                {
                    b.HasBaseType("TheBookCave.Data.EntityModels.User");

                    b.Property<string>("name");

                    b.Property<string>("phoneNumber");

                    b.Property<string>("socialSecurityNumber");

                    b.Property<int>("userId");

                    b.ToTable("Customer");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("TheBookCave.Data.EntityModels.Cart", b =>
                {
                    b.HasOne("TheBookCave.Data.EntityModels.Book", "book")
                        .WithMany()
                        .HasForeignKey("bookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
