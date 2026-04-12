namespace FitnessTracker.Domain.Entities
{
    public class Workout : BaseEntity
    {
        public string Name { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.UtcNow;

        // FK
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        // Navigation
        public List<WorkoutExercise> WorkoutExercises { get; set; } = new();
    }
}
