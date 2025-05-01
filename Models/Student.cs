using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationApp.Models {
    public class Student {
        public int Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName {
            get; set;
        }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
