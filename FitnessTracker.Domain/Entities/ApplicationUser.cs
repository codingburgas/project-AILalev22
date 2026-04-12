using Microsoft.AspNetCore.Identity;

namespace FitnessTracker.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
