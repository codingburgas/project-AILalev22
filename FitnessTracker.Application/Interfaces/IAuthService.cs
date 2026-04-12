using FitnessTracker.Application.DTOs.Users;

namespace FitnessTracker.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetUserIdAsync(string username);

        Task<bool> IsAdminAsync(string userId);

        Task<ApplicationUserDto?> GetUserAsync(string userId);
    }
}