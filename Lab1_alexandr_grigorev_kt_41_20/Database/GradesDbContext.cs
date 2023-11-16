using Lab1_alexandr_grigorev_kt_41_20;
using Lab3.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

using static System.Net.Mime.MediaTypeNames;

namespace Lab3.Database
{
    public class GradesDbContext : DbContext
    {


        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }

        public GradesDbContext(DbContextOptions<GradesDbContext> options) : base(options)
        {

        }
    }
}