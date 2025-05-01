using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationApp.Models.ViewModels {
    public class StudentViewModel {
        public int Id { get; set; }
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email {  get; set; }
    }
}
