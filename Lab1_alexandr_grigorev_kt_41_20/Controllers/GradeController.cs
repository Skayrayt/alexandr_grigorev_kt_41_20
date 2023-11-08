using Lab1_alexandr_grigorev_kt_41_20.Interfaces.GradeInterfaces;
using Lab3.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherForecast;

namespace Lab1_alexandr_grigorev_kt_41_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Lab1_alexandr_grigorev_kt_41_20Controller : ControllerBase
    {

        private readonly ILogger<Lab1_alexandr_grigorev_kt_41_20Controller> _logger;
        private readonly IGradeService _gradeService;
        private GradesDbContext _dbContext;
        

        public Lab1_alexandr_grigorev_kt_41_20Controller(ILogger<Lab1_alexandr_grigorev_kt_41_20Controller> logger, GradesDbContext dbContext, IGradeService gradeService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _gradeService = gradeService;
        }

        [HttpGet("Get grades")]
        public async Task<IActionResult> GetGradesAsync(CancellationToken cancellationToken = default)
        {
            var grades = await _gradeService.GetGradesAsync(cancellationToken);
            return Ok(grades);
        }

        [HttpPost("Add grades")]
        [ActionName(nameof(AddGradeAsync))]
        public async Task<IActionResult> AddGradeAsync(Grade grade, CancellationToken cancellationToken = default)
        {
            await _gradeService.AddGradeAsync(grade, cancellationToken);
            return CreatedAtAction(nameof(AddGradeAsync), new { id = grade.GradeId }, grade);
        }

        [HttpPut("Update grades with id")]
        public async Task<IActionResult> UpdateGradeAsync(int id, Grade grade, CancellationToken cancellationToken = default)
        {
            if (id != grade.GradeId)
            {
                return BadRequest();
            }
            await _gradeService.UpdateGradeAsync(grade, cancellationToken);
            return Ok();
        }
    }
    }