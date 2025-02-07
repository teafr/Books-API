﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_api_for_books_app.Contexts;

#nullable disable

namespace web_api_for_books_app.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("web_api_for_books_app.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("full_name");

                    b.HasKey("Id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.BookAndUser", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("m2m_books_users");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int>("ReviwerId")
                        .HasColumnType("int")
                        .HasColumnName("reviewer_id");

                    b.Property<string>("Text")
                        .HasColumnType("longtext")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReviwerId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.Book", b =>
                {
                    b.HasOne("web_api_for_books_app.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.BookAndUser", b =>
                {
                    b.HasOne("web_api_for_books_app.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_api_for_books_app.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.Review", b =>
                {
                    b.HasOne("web_api_for_books_app.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_api_for_books_app.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviwerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.Book", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("web_api_for_books_app.Models.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
