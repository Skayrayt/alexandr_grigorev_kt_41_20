using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab1_alexandr_grigorev_kt_41_20
{
    public class Grade
    {
        public int? GradeId { get; set; }

        public int? GradeNumber { get; set; }

        public DateTime? GradeDate { get; set; }

        public int? StudentId { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }

        
    }
}