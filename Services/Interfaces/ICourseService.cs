using CourseRegistrationApp.Models;
using CourseRegistrationApp.Models.ViewModels;

namespace CourseRegistrationApp.Services.Interfaces {
    public interface ICourseService {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetDetailsAsync(int? id);
        Task CreateAsync(CourseVIewModel course);
        Task UpdateAsync(int id, CourseVIewModel course);

        Task DeleteAsync(int id);
        bool CourseExists(int id);
    }
}
