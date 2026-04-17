using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Infrastructure;
using FitnessTracker.Application;

namespace FitnessTracker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddApplication();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Logout";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });

            builder.Services.AddAuthentication();

            builder.Services.AddAuthorization();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                // 1. Create roles
                string[] roles = { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // 2. Get admin email safely
                var adminEmail = app.Configuration["Other:adminEmail"];

                if (string.IsNullOrWhiteSpace(adminEmail))
                    return;

                // 3. Try find admin
                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                // 4. Create admin if not exists
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        EmailConfirmed = true
                    };

                    var createResult = await userManager.CreateAsync(adminUser, app.Configuration["Other:adminPassword"]!);

                    if (!createResult.Succeeded)
                        throw new Exception("Failed to create admin user");
                }

                // 5. Ensure Admin role is assigned
                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Statistics}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
