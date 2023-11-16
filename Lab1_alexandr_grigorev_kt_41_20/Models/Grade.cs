using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherForecast
{
    public class Grade
    {
        public int? GradeId { get; set; }

        public int? GradeNumber { get; set; }

        public DateTime? GradeDate { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        
    }
}