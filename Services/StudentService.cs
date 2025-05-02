
using CourseRegistrationApp.Data.Infrastructure;
using CourseRegistrationApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

public class StudentService : IStudentService {
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<StudenDashboardViewModel> GetDashboardDataAsync(string studentId) {
        var student = await _context.Users
            .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.Id == studentId);

        if (student == null) return null;

        return new StudenDashboardViewModel {
            FirstName = student.FirstName,
            LastName = student.LastName,
            EnrolledCourses = student.Enrollments.Select(e => new StudenDashboardViewModel.CourseInfo {
                Name = e.Course.Name,
                CreditHours = e.Course.CreditHours,
                EnrolledOn = e.EnrolledOn
            }).ToList()
        };
    }
}













//using System.Runtime.InteropServices;
//using CourseRegistrationApp.Data.Infrastructure;
//using CourseRegistrationApp.Models;
//using CourseRegistrationApp.Models.ViewModels;
//using CourseRegistrationApp.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace CourseRegistrationApp.Services {
//    public class StudentService : IStudentService {
//        private readonly ApplicationDbContext _context;

//        public StudentService(ApplicationDbContext context) {
//            _context = context;
//        }

//        public async Task CreateAsync(StudentViewModel student) {
//            var newStudent = new Student { FirstName = student.FirstName, LastName = student.LastName, Email = student.Email };
//            _context.Students.Add(newStudent);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id) {
//            var student = await _context.Students.FindAsync(id);
//            if (student != null)
//                _context.Students.Remove(student);
//            await _context.SaveChangesAsync();

//        }

//        public async Task<List<Student>> GetAllAsync() {
//            return await _context.Students.ToListAsync();
//        }

//        public async Task<Student?> GetDetailsAsync(int? id) {
//            return await _context.Students.FirstOrDefaultAsync(i => i.Id == id);
//        }

//        public async Task UpdateAsync(int id, StudentViewModel student) {
//            var updated = await _context.Students.FindAsync(id);
//            if(updated!= null) {
//                updated.FirstName = student.FirstName;
//                updated.LastName = student.LastName;
//                updated.Email = student.Email;
//                await _context.SaveChangesAsync();
//            }
//        }
//        public bool StudentExists(int id) {
//            return _context.Students.Any(e => e.Id == id);
//        }
//    }
//}
