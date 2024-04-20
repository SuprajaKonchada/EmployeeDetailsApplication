﻿// <auto-generated />
using System;
using EmployeeDetailsApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeDetailsApplication.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240420120524_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Experience")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("SkillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Employee", b =>
                {
                    b.HasOne("EmployeeDetailsApplication.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Project", b =>
                {
                    b.HasOne("EmployeeDetailsApplication.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeDetailsApplication.Models.Employee", null)
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Skill", b =>
                {
                    b.HasOne("EmployeeDetailsApplication.Models.Department", "Department")
                        .WithMany("Skills")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeDetailsApplication.Models.Employee", null)
                        .WithMany("Skills")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("EmployeeDetailsApplication.Models.Employee", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
