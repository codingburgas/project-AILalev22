namespace FitnessTracker.Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; } = null!;

        // Example: "Strength", "Cardio"
        public string Type { get; set; } = null!;

        // Calories burned per minute (base value)
        public double CaloriesPerMinute { get; set; }

        // Navigation
        public List<WorkoutExercise> WorkoutExercises { get; set; } = new();
    }
}
