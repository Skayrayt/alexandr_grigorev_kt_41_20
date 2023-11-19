using Lab3.Database;
using Microsoft.EntityFrameworkCore;


namespace Lab1_alexandr_grigorev_kt_41_20.Interfaces.GradeInterfaces
{
    public interface IGradeService
    {
        public Task<Grade[]> GetGradesAsync(CancellationToken cancellationToken);
        public Task AddGradeAsync(Grade grade, CancellationToken cancellationToken);
        public Task UpdateGradeAsync(Grade grade, CancellationToken cancellationToken);
    }

    public class GradeService : IGradeService
    {
        public readonly GradesDbContext _dbContext;
        public GradeService(GradesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Grade[]> GetGradesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Grades.Select(d => new Grade
            {
                GradeId = d.GradeId,
                GradeNumber = d.GradeNumber,
                GradeDate = d.GradeDate,
                StudentId = d.StudentId
            }).ToArrayAsync();
        }

        public async Task AddGradeAsync(Grade grade, CancellationToken cancellationToken = default)
        {
            var student = await _dbContext.Students.FindAsync(grade.StudentId);
            grade.Student = student;

            _dbContext.Grades.Add(grade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGradeAsync(Grade grade, CancellationToken cancellationToken = default)
        {
            var student = await _dbContext.Students.FindAsync(grade.StudentId);
            grade.Student = student;

            _dbContext.Grades.Update(grade);
            await _dbContext.SaveChangesAsync();
        }
    }
}
