namespace FitnessTracker.Application.DTOs.Users
{
    public class ApplicationUserDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
