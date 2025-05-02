using CourseRegistrationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationApp.Controllers {
    [Authorize(Roles = "Student")]
    public class StudentDashboardController : Controller {
        private readonly UserManager<Student> _userManager;
        private readonly IStudentService _studentService;

        public StudentDashboardController(UserManager<Student> userManager, IStudentService studentService) {
            _userManager = userManager;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index() {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var dashboardData = await _studentService.GetDashboardDataAsync(user.Id);
            if (dashboardData == null) return NotFound();

            return View(dashboardData);
        }
    }
}
