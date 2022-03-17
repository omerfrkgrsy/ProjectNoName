﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectNoName.Repository.EntityFramework.Context;

#nullable disable

namespace ProjectNoName.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220317185546_follewersandlike")]
    partial class follewersandlike
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectNoName.Entities.Concrete.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Audio")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("POST");
                });

            modelBuilder.Entity("ProjectNoName.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<bool>("isPrivated")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("ProjectNoName.Entities.Like", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PostId");

                    b.HasIndex("Id");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("ProjectNoName.Entities.RelationShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FollewerId")
                        .HasColumnType("integer");

                    b.Property<int>("FollowedId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("FollewerId");

                    b.HasIndex("FollowedId");

                    b.ToTable("RelationShips");
                });

            modelBuilder.Entity("ProjectNoName.Entities.Concrete.Post", b =>
                {
                    b.HasOne("ProjectNoName.Entities.Concrete.Post", "Parent")
                        .WithMany("SubPosts")
                        .HasForeignKey("ParentId");

                    b.HasOne("ProjectNoName.Entities.Concrete.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectNoName.Entities.Like", b =>
                {
                    b.HasOne("ProjectNoName.Entities.Concrete.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectNoName.Entities.Concrete.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectNoName.Entities.RelationShip", b =>
                {
                    b.HasOne("ProjectNoName.Entities.Concrete.User", "Follewer")
                        .WithMany("Followers")
                        .HasForeignKey("FollewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectNoName.Entities.Concrete.User", "Follewed")
                        .WithMany("Followed")
                        .HasForeignKey("FollowedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follewed");

                    b.Navigation("Follewer");
                });

            modelBuilder.Entity("ProjectNoName.Entities.Concrete.Post", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("SubPosts");
                });

            modelBuilder.Entity("ProjectNoName.Entities.Concrete.User", b =>
                {
                    b.Navigation("Followed");

                    b.Navigation("Followers");

                    b.Navigation("Likes");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}