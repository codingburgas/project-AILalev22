namespace FitnessTracker.Application.DTOs.Stats
{
    public class WeeklyStatsDto
    {
        public double TotalCaloriesBurned { get; set; }
        public int TotalWorkouts { get; set; }

        public Dictionary<string, double> CaloriesByDay { get; set; } = new();
    }
}