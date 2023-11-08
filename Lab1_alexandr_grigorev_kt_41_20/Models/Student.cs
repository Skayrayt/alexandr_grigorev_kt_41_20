namespace WeatherForecast
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SecName { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}