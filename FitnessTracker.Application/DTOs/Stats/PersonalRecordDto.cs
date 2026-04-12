namespace FitnessTracker.Application.DTOs.Stats
{
    public class PersonalRecordDto
    {
        public string ExerciseName { get; set; } = null!;
        public int MaxReps { get; set; }
        public int MaxSets { get; set; }
        public int LongestDuration { get; set; }
    }
}