using CourseRegistrationApp.Data.Infrastructure;
using CourseRegistrationApp.Models;
using CourseRegistrationApp.Models.ViewModels;
using CourseRegistrationApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationApp.Services {
    public class CourseService : ICourseService {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task CreateAsync(CourseVIewModel course) {
            var newCourse = new Course { Name = course.Name, CreditHours = course.CreditHours };
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
                _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Course>> GetAllAsync() {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetDetailsAsync(int? id) {
            return await _context.Courses.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(int id, CourseVIewModel course) {
            var updated = await _context.Courses.FindAsync(id);
            if (updated != null) {
                updated.Name = course.Name;
                updated.CreditHours = course.CreditHours;
                await _context.SaveChangesAsync();
            }
        }
        public bool CourseExists(int id) {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
