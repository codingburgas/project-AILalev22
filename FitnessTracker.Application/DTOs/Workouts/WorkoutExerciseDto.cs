namespace FitnessTracker.Application.DTOs.Workouts
{
    public class WorkoutExerciseDto
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; } = null!;
        public string Type { get; set; } = null!;

        public int Sets { get; set; }
        public int Reps { get; set; }
        public int DurationMinutes { get; set; }

        public string Intensity { get; set; } = null!;

        public double CaloriesBurned { get; set; }
    }
}