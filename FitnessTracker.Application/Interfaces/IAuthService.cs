using FitnessTracker.Application.DTOs.Users;

namespace FitnessTracker.Application.Interfaces
{
    public interface IAuthService
    {
        // REGISTER
        Task<bool> RegisterAsync(RegisterDto dto);

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