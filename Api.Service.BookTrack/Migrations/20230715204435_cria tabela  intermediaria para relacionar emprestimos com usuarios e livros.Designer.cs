﻿// <auto-generated />
using System;
using Api.Service.BookTrack.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Service.BookTrack.Migrations
{
    [DbContext(typeof(ApiServiceDbContext))]
    [Migration("20230715204435_cria tabela  intermediaria para relacionar emprestimos com usuarios e livros")]
    partial class criatabelaintermediariapararelacionaremprestimoscomusuarioselivros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Service.BookTrack.Models.AuthorizationModel", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DbUserUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Uid");

                    b.HasIndex("DbUserUid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("Api.Service.BookTrack.Models.BookModel", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("Acquisition")
                        .HasColumnType("datetime2");

                    b.Property<string>("Authors")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<byte[]>("BookCover")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("CopiesRented")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Publication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int");

                    b.Property<int>("TotalPages")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Api.Service.BookTrack.Models.LoanModel", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("BookUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LoansAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoansStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Uid");

                    b.HasIndex("BookUid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.HasIndex("UserUid");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Api.Service.BookTrack.Models.UserModel", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.HasIndex("Login")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Login"), new[] { "Password" });

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Service.BookTrack.Models.AuthorizationModel", b =>
                {
                    b.HasOne("Api.Service.BookTrack.Models.UserModel", "DbUser")
                        .WithMany("DbRoles")
                        .HasForeignKey("DbUserUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbUser");
                });

            modelBuilder.Entity("Api.Service.BookTrack.Models.LoanModel", b =>
                {
                    b.HasOne("Api.Service.BookTrack.Models.BookModel", "DbBook")
                        .WithMany("DbLoans")
                        .HasForeignKey("BookUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Service.BookTrack.Models.UserModel", "DbUser")
                        .WithMany("DbLoans")
                        .HasForeignKey("UserUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbBook");

                    b.Navigation("DbUser");
                });

            modelBuilder.Entity("Api.Service.BookTrack.Models.BookModel", b =>
                {
                    b.Navigation("DbLoans");
                });

            modelBuilder.Entity("Api.Service.BookTrack.Models.UserModel", b =>
                {
                    b.Navigation("DbLoans");

                    b.Navigation("DbRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
