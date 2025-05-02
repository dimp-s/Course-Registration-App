namespace CourseRegistrationApp.Models {
    public class Enrollment {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrolledOn { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
