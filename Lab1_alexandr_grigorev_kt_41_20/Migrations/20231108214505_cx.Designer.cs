﻿// <auto-generated />
using System;
using Lab3.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lab1_alexandr_grigorev_kt_41_20.Migrations
{
    [DbContext(typeof(GradesDbContext))]
    [Migration("20231108214505_cx")]
    partial class cx
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WeatherForecast.Grade", b =>
                {
                    b.Property<int?>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("grade_id")
                        .HasComment("Идентификатор успеваемости");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("GradeId"));

                    b.Property<DateTime?>("GradeDate")
                        .IsRequired()
                        .HasColumnType("timestamp")
                        .HasColumnName("c_student_gradedate")
                        .HasComment("Дата оценки");

                    b.Property<int?>("GradeNumber")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("c_student_gradenumber")
                        .HasComment("Оценка");

                    b.Property<int?>("StudentId")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("c_student_studentid")
                        .HasComment("Идентификатор студента");

                    b.HasKey("GradeId")
                        .HasName("pk_(TableName)_GradeId");

                    b.HasIndex(new[] { "StudentId" }, "idx_(TableName)_fk_f_student_id");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("WeatherForecast.Student", b =>
                {
                    b.Property<int?>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("student_id")
                        .HasComment("Идентификатор записи студента");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_firstname")
                        .HasComment("Имя студента");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_lastname")
                        .HasComment("Фамилия студента");

                    b.Property<string>("SecName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_secname")
                        .HasComment("Отчество студента");

                    b.HasKey("StudentId")
                        .HasName("pk_(TableName)_StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WeatherForecast.Grade", b =>
                {
                    b.HasOne("WeatherForecast.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_student_id");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WeatherForecast.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}