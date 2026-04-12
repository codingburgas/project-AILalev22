namespace FitnessTracker.Application.DTOs.Workouts
{
    public class UpdateWorkoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}