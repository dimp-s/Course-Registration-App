using CourseRegistrationApp.Models.ViewModels;
using CourseRegistrationApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationApp.Controllers {
    public class AccountController : Controller {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) { _accountService = accountService; }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) {
   
            if (ModelState.IsValid) {
                var result = await _accountService.RegisterUserAsync(model);
                if (result.Succeeded) {
                    //login the user
                    await _accountService.LogInUserAsync(new LoginViewModel { Email = model.Email, Password = model.Password });
                    Console.WriteLine("Im here");
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                var result = await _accountService.LogInUserAsync(model);
                if (result.Succeeded) {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout() {
            await _accountService.LogoutUserAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UnAuthorized() {
            return View();
        }
    }
}

