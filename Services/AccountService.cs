using CourseRegistrationApp.Models;
using CourseRegistrationApp.Models.ViewModels;
using CourseRegistrationApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CourseRegistrationApp.Services {

    public class AccountService : IAccountService {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;
        public AccountService(UserManager<Student> userManager, SignInManager<Student> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> LogInUserAsync(LoginViewModel model) {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) {
                return SignInResult.Failed;
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            return result;
        }

        public async Task LogoutUserAsync() {
            await _signInManager.SignOutAsync();
            
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model) {
            var user = new Student { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, ProfileImage = "images/default-avatar.png"};
            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
                await _userManager.AddToRoleAsync(user, "Student");
            return result;
        }
    }
}
