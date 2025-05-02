using CourseRegistrationApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CourseRegistrationApp.Services.Interfaces {
    public interface IAccountService {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
        Task<SignInResult> LogInUserAsync(LoginViewModel model);
        Task LogoutUserAsync();
    }
}
