﻿﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Lab1_alexandr_grigorev_kt_41_20.Database.Helpers;
using Lab1_alexandr_grigorev_kt_41_20;

namespace Lab3.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "Student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                    .HasKey(p => p.StudentId)
                    .HasName($"pk_(TableName)_StudentId");

            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.SecName)
                .IsRequired()
                .HasColumnName("c_student_secname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество студента");

        }
    }
}