using CourseRegistrationApp.Data.Infrastructure;
using CourseRegistrationApp.Models;
using CourseRegistrationApp.Models.ViewModels;
using CourseRegistrationApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationApp.Services {
    public class EnrollmentService : IEnrollmentService {
        private readonly ApplicationDbContext _context;

        public EnrollmentService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<EnrollmentViewModel>> GetAvailableCoursesAsync(string studentId) {
            var enrolledCourseIds = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Select(e => e.CourseId)
                .ToListAsync();

            var allCourses = await _context.Courses.ToListAsync();

            return allCourses.Select(course => new EnrollmentViewModel {
                CourseId = course.Id,
                CourseName = course.Name,
                CreditHours = course.CreditHours,
                IsEnrolled = enrolledCourseIds.Contains(course.Id)
            }).ToList();
        }

        public async Task<bool> EnrollStudentAsync(string studentId, int courseId) {
            var alreadyEnrolled = await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);

            if (alreadyEnrolled)
                return false;

            var enrollment = new Enrollment {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledOn = DateTime.UtcNow
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
