namespace FitnessTracker.Application.DTOs.Workouts
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }

        public int TotalExercises { get; set; }
        public double TotalCaloriesBurned { get; set; }
    }
}