namespace FitnessTracker.Application.DTOs.Workouts
{
    public class WorkoutDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }

        public List<WorkoutExerciseDto> Exercises { get; set; } = new();

        public double TotalCaloriesBurned { get; set; }
    }
}