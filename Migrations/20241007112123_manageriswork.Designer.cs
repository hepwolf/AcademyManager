﻿// <auto-generated />
using System;
using AcademyManager.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcademyManager.Migrations
{
    [DbContext(typeof(AcademyDbContext))]
    [Migration("20241007112123_manageriswork")]
    partial class manageriswork
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AcademyManager.Domain.Entities.Academy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Academy", (string)null);
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AcademyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AcademyId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.StudentCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse", (string)null);
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("UserAccunt", (string)null);
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.UserToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken", (string)null);
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.Course", b =>
                {
                    b.HasOne("AcademyManager.Domain.Entities.Academy", null)
                        .WithMany("Courses")
                        .HasForeignKey("AcademyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.StudentCourse", b =>
                {
                    b.HasOne("AcademyManager.Domain.Entities.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademyManager.Domain.Entities.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.UserToken", b =>
                {
                    b.HasOne("AcademyManager.Domain.Entities.UserAccount", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.Academy", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("AcademyManager.Domain.Entities.UserAccount", b =>
                {
                    b.Navigation("UserTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
