using CourseRegistrationApp.Data.Infrastructure;
using CourseRegistrationApp.Models;
using CourseRegistrationApp.Services;
using CourseRegistrationApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
// Add services to the container.

//identity
builder.Services.AddIdentity<Student, IdentityRole>(
    options => {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6; // Minimum password length of 8
        options.Password.RequireNonAlphanumeric = false; // At least one special character
        options.Password.RequireUppercase = true; // At least one uppercase letter
        options.Password.RequireLowercase = true; // At least one lowercase letter
    }).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure the application cookie
builder.Services.ConfigureApplicationCookie(options => {
    // Redirect unauthorized users to the custom Unauthorized page
    options.Events = new CookieAuthenticationEvents {
        OnRedirectToAccessDenied = context => {
            context.Response.Redirect("/Account/Unauthorized");
            return Task.CompletedTask;
        },
        OnRedirectToLogin = context => {
            context.Response.Redirect("/Account/Login");
            return Task.CompletedTask;
        }
    };
});

//add DI services
//builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles
using (var scope = app.Services.CreateScope()) {
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Student>>();
    var roles = new[] { "Admin", "Student" };

    foreach (var role in roles) {
        if (!await roleManager.RoleExistsAsync(role)) {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
    var admin = await userManager.FindByNameAsync("Admin");
    if (admin == null) {
        var newAdmin = new Student {FirstName = "Admin", LastName="Admin", Email = "admin@admin.com", UserName = "admin@admin.com" };
        var result = await userManager.CreateAsync(newAdmin, "Admin123");
        if (result.Succeeded)
            await userManager.AddToRoleAsync(newAdmin, "Admin");
        }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.MapStaticAssets();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
