

using CourseRegistrationApp.Models.ViewModels;

public interface IStudentService {
    Task<StudenDashboardViewModel> GetDashboardDataAsync(string studentId);
    Task<String> UploadProfilePhotoAsync(string studentId, IFormFile profileImage);
}
