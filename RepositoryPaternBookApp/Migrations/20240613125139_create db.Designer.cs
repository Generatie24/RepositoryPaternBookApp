﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryPaternBookApp.Data;

#nullable disable

namespace RepositoryPaternBookApp.Migrations
{
    [DbContext(typeof(RepoContext))]
    [Migration("20240613125139_create db")]
    partial class createdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AuthorId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Name = "Author 1"
                        },
                        new
                        {
                            AuthorId = 2,
                            Name = "Author 2"
                        });
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int?>("BindingType")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBestSeller")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNewRelease")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            BindingType = 0,
                            ImagePath = "",
                            IsAvailable = true,
                            IsBestSeller = false,
                            IsNewRelease = true,
                            Title = "Book 1"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            BindingType = 1,
                            ImagePath = "",
                            IsAvailable = false,
                            IsBestSeller = true,
                            IsNewRelease = false,
                            Title = "Book 2"
                        });
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            BookId = 2,
                            GenreId = 2
                        });
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GenreId");

                    b.HasIndex("BookId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Genre 1"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "Genre 2"
                        });
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Book", b =>
                {
                    b.HasOne("RepositoryPaternBookApp.Models.DomainModels.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.BookGenre", b =>
                {
                    b.HasOne("RepositoryPaternBookApp.Models.DomainModels.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryPaternBookApp.Models.DomainModels.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Genre", b =>
                {
                    b.HasOne("RepositoryPaternBookApp.Models.DomainModels.Book", null)
                        .WithMany("Genres")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Book", b =>
                {
                    b.Navigation("BookGenres");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("RepositoryPaternBookApp.Models.DomainModels.Genre", b =>
                {
                    b.Navigation("BookGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
