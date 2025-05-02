using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationApp.Models.ViewModels {
    public class RegisterViewModel {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public required string ConfirmPassword { get; set; }
    }
}
