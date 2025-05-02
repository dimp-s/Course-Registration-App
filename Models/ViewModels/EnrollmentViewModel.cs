namespace CourseRegistrationApp.Models.ViewModels {
    public class EnrollmentViewModel {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CreditHours { get; set; }


        public bool IsEnrolled { get; set; }
    }
}
