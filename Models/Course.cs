using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CourseRegistrationApp.Models {
    public class Course {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public int CreditHours { get; set; }

        public virtual ICollection<Enrollment> Enrollments {get; set;}
    }
}
