using Lab3.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using WeatherForecast;
using static Lab1_alexandr_grigorev_kt_41_20.WeatherForecast;
using static System.Net.Mime.MediaTypeNames;

namespace Lab3.Database
{
    public class StudentDbContext : DbContext
    {

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<WeatherForecast.Group> Groups { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
    }
}