﻿// <auto-generated />
using System;
using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240225213317_AddTablesWithRelationships")]
    partial class AddTablesWithRelationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment3.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("MinDegree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Assignment3.Models.CourseResult", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId1")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int?>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int?>("TraineeId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseId1")
                        .IsUnique()
                        .HasFilter("[CourseId1] IS NOT NULL");

                    b.HasIndex("TraineeId");

                    b.HasIndex("TraineeId1")
                        .IsUnique()
                        .HasFilter("[TraineeId1] IS NOT NULL");

                    b.ToTable("CourseResults");
                });

            modelBuilder.Entity("Assignment3.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("ManagerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TraineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("TraineeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Assignment3.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId1")
                        .HasColumnType("int");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseId1")
                        .IsUnique()
                        .HasFilter("[CourseId1] IS NOT NULL");

                    b.HasIndex("DeptId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Assignment3.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.ToTable("Traines");
                });

            modelBuilder.Entity("Assignment3.Models.Course", b =>
                {
                    b.HasOne("Assignment3.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DeptId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Assignment3.Models.CourseResult", b =>
                {
                    b.HasOne("Assignment3.Models.Course", "Course")
                        .WithMany("CourseResults")
                        .HasForeignKey("CourseId");

                    b.HasOne("Assignment3.Models.Course", null)
                        .WithOne("CourseResult")
                        .HasForeignKey("Assignment3.Models.CourseResult", "CourseId1");

                    b.HasOne("Assignment3.Models.Trainee", "Trainee")
                        .WithMany("CourseResults")
                        .HasForeignKey("TraineeId");

                    b.HasOne("Assignment3.Models.Trainee", null)
                        .WithOne("CourseResult")
                        .HasForeignKey("Assignment3.Models.CourseResult", "TraineeId1");

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Assignment3.Models.Department", b =>
                {
                    b.HasOne("Assignment3.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Assignment3.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.HasOne("Assignment3.Models.Trainee", "Trainee")
                        .WithMany()
                        .HasForeignKey("TraineeId");

                    b.Navigation("Course");

                    b.Navigation("Instructor");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Assignment3.Models.Instructor", b =>
                {
                    b.HasOne("Assignment3.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment3.Models.Course", null)
                        .WithOne("Instructor")
                        .HasForeignKey("Assignment3.Models.Instructor", "CourseId1");

                    b.HasOne("Assignment3.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Assignment3.Models.Trainee", b =>
                {
                    b.HasOne("Assignment3.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Assignment3.Models.Course", b =>
                {
                    b.Navigation("CourseResult");

                    b.Navigation("CourseResults");

                    b.Navigation("Instructor");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Assignment3.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("Assignment3.Models.Trainee", b =>
                {
                    b.Navigation("CourseResult");

                    b.Navigation("CourseResults");
                });
#pragma warning restore 612, 618
        }
    }
}