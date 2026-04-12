namespace FitnessTracker.Application.DTOs.Exercises
{
    public class CreateExerciseDto
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public double CaloriesPerMinute { get; set; }
    }
}