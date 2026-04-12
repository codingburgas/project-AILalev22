namespace FitnessTracker.Application.DTOs.Workouts
{
    public class CreateWorkoutDto
    {
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}