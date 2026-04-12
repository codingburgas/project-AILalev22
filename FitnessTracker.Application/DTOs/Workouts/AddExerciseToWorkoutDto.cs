namespace FitnessTracker.Application.DTOs.Workouts
{
    public class AddExerciseToWorkoutDto
    {
        public int WorkoutId { get; set; }
        public int ExerciseId { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }
        public int DurationMinutes { get; set; }

        public string Intensity { get; set; } = null!;
    }
}