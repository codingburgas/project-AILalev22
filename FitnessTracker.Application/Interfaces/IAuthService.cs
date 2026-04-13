using FitnessTracker.Application.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace FitnessTracker.Application.Interfaces
{
    public interface IAuthService
    {
        // REGISTER
        Task<IdentityResult> RegisterAsync(RegisterDto dto);

        // LOGIN
        Task<bool> LoginAsync(LoginDto dto);

        // LOGOUT
        Task LogoutAsync();

        // USER INFO
        Task<string?> GetUserIdAsync(string username);

        Task<ApplicationUserDto?> GetUserAsync(string userId);

        Task<bool> IsAdminAsync(string userId);
    }
}