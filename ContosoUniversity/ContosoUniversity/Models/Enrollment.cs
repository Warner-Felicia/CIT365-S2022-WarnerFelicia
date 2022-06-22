using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        // ReSharper disable once InconsistentNaming
        public int EnrollmentID { get; set; }
        // ReSharper disable once InconsistentNaming
        public int CourseID { get; set; }
        // ReSharper disable once InconsistentNaming
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
