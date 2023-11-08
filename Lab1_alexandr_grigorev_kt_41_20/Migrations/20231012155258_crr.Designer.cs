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
    [Migration("20231012155258_crr")]
    partial class crr
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

                    b.Property<int?>("SubjectId")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("c_student_subjectid")
                        .HasComment("Идентификатор предмета");

                    b.HasKey("GradeId")
                        .HasName("pk_(TableName)_GradeId");

                    b.HasIndex(new[] { "StudentId" }, "idx_(TableName)_fk_f_student_id");

                    b.HasIndex(new[] { "SubjectId" }, "idx_(TableName)_fk_f_subject_id");

                    b.ToTable("Grade", (string)null);
                });

            modelBuilder.Entity("WeatherForecast.Group", b =>
                {
                    b.Property<int?>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("group_id")
                        .HasComment("Идентификатор группы");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_groupname")
                        .HasComment("Наименование группы");

                    b.HasKey("GroupId")
                        .HasName("pk_(TableName)_GroupId");

                    b.ToTable("Groups");
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

                    b.Property<int?>("GroupId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("int4")
                        .HasColumnName("c_student_groupid")
                        .HasComment("Идентификатор группы");

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

                    b.HasIndex("GroupId");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("WeatherForecast.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("subject_id")
                        .HasComment("Идентификатор предмета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_subjectname")
                        .HasComment("Наименование предмета");

                    b.HasKey("SubjectId")
                        .HasName("pk_(TableName)_SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WeatherForecast.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("test_id")
                        .HasComment("Идентификатор успеваемости (зачеты)");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TestId"));

                    b.Property<DateTime?>("DateOfTest")
                        .IsRequired()
                        .HasColumnType("timestamp")
                        .HasColumnName("c_student_dateoftest")
                        .HasComment("Дата зачета");

                    b.Property<int?>("StudentId")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("c_student_studentid")
                        .HasComment("Идентификатор студента");

                    b.Property<int?>("SubjectId")
                        .IsRequired()
                        .HasColumnType("int4")
                        .HasColumnName("c_student_subjectid")
                        .HasComment("Идентификатор предмета");

                    b.Property<string>("TestCondition")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_testcondition")
                        .HasComment("Итог зачета");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_testname")
                        .HasComment("Наименование зачета");

                    b.HasKey("TestId")
                        .HasName("pk_(TableName)_TestId");

                    b.HasIndex(new[] { "StudentId" }, "idx_(TableName)_fk_f_student_id")
                        .HasDatabaseName("idx_(TableName)_fk_f_student_id1");

                    b.HasIndex(new[] { "SubjectId" }, "idx_(TableName)_fk_f_subject_id")
                        .HasDatabaseName("idx_(TableName)_fk_f_subject_id1");

                    b.ToTable("Test", (string)null);
                });

            modelBuilder.Entity("WeatherForecast.Grade", b =>
                {
                    b.HasOne("WeatherForecast.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_student_id");

                    b.HasOne("WeatherForecast.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WeatherForecast.Student", b =>
                {
                    b.HasOne("WeatherForecast.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_group_id");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("WeatherForecast.Test", b =>
                {
                    b.HasOne("WeatherForecast.Student", "Student")
                        .WithMany("Tests")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_student_id");

                    b.HasOne("WeatherForecast.Subject", "Subject")
                        .WithMany("Tests")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WeatherForecast.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("WeatherForecast.Student", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("WeatherForecast.Subject", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Tests");
                });
#pragma warning restore 612, 618
        }
    }
}
