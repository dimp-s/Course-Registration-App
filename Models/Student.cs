using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CourseRegistrationApp.Models {
    public class Student : IdentityUser {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName {
            get; set;
        }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
