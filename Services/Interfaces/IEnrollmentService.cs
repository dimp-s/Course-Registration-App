using CourseRegistrationApp.Models.ViewModels;

namespace CourseRegistrationApp.Services.Interfaces {
    public interface IEnrollmentService {
        Task<List<EnrollmentViewModel>> GetAvailableCoursesAsync(string studentId);
        Task<bool> EnrollStudentAsync(string studentId, int courseId);
    }
}
