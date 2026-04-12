using FitnessTracker.Application.DTOs.Workouts;

namespace FitnessTracker.Application.DTOs.Users
{
    public class UserWithWorkoutsDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public List<WorkoutDto> Workouts { get; set; } = new();
    }
}