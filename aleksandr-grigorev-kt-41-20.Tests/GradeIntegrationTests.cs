using Lab1_alexandr_grigorev_kt_41_20.Interfaces.GradeInterfaces;
using Lab3.Database;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherForecast;

namespace aleksandr_grigorev_kt_41_20.Tests
{
    public class GradeIntegrationTests
    {
        public readonly DbContextOptions<GradesDbContext> _dbContextOptions;

        public GradeIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GradesDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;
        }
        [Fact]
        public async Task AddGradeAsync_AddsGrade()
        {
            // Arrange
            var ctx = new GradesDbContext(_dbContextOptions);
            var gradeService = new GradeService(ctx);

            var student = new Student
            {
                FirstName = "Орлов",
                LastName = "Максим",
                SecName = "Белорусович"
            };
            await ctx.Set<Student>().AddAsync(student);
            await ctx.SaveChangesAsync();

            var grade = new Grade
            {
                GradeNumber = 3,
                GradeDate = new DateTime(2023, 01, 25),
                StudentId = student.StudentId
            };

            // Act
            await gradeService.AddGradeAsync(grade);

            // Assert
            var addedGrade = await ctx.Set<Grade>().SingleOrDefaultAsync(s => s.GradeNumber == 3);
            Assert.NotNull(addedGrade);
            Assert.Equal(new DateTime(2023, 01, 25), addedGrade.GradeDate);
            Assert.Equal(student.StudentId, addedGrade.StudentId);
        }
        [Fact]
        public async Task UpdateGradeAsync_Id_Student()
        {
            // Arrange
            var ctx = new GradesDbContext(_dbContextOptions);
            var gradeService = new GradeService(ctx);
            var grade = new Grade
            {
                GradeNumber = 4,
                GradeDate = new DateTime(2023, 12, 10),
                StudentId = 1
            };
            await ctx.Set<Grade>().AddAsync(grade);
            await ctx.SaveChangesAsync();

            // Act
            grade.GradeNumber = 5;
            grade.GradeDate = new DateTime(2023, 12, 10);
            grade.StudentId = 1;
            await gradeService.UpdateGradeAsync(grade, CancellationToken.None);

            // Assert
            Assert.Equal(5, grade.GradeNumber);
        }
    }
}
