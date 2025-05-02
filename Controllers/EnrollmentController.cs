using CourseRegistrationApp.Models;
using CourseRegistrationApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationApp.Controllers {
    [Authorize(Roles = "Student")]
    public class EnrollmentController : Controller {
        private readonly IEnrollmentService _enrollmentService;
        private readonly UserManager<Student> _userManager;

        public EnrollmentController(IEnrollmentService enrollmentService, UserManager<Student> userManager) {
            _enrollmentService = enrollmentService;
            _userManager = userManager;
        }

        // GET: /Enrollment
        public async Task<IActionResult> Index() {
            var student = await _userManager.GetUserAsync(User);
            var courses = await _enrollmentService.GetAvailableCoursesAsync(student.Id);
            return View(courses);
        }

        // POST: /Enrollment/Enroll
        [HttpPost]
        public async Task<IActionResult> Enroll(int courseId) {
            var student = await _userManager.GetUserAsync(User);
            var success = await _enrollmentService.EnrollStudentAsync(student.Id, courseId);

            if (!success)
                TempData["Error"] = "You are already enrolled in this course.";

            return RedirectToAction(nameof(Index));
        }
    }
}
