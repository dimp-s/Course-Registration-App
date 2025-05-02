using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationApp.Models.ViewModels {
    public class CourseVIewModel {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public int CreditHours { get; set; }
    }
}
