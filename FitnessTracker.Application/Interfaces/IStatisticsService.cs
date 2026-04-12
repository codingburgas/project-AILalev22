using FitnessTracker.Application.DTOs.Stats;

namespace FitnessTracker.Application.Interfaces
{
    public interface IStatisticsService
    {
        // TIME-BASED STATS
        Task<WeeklyStatsDto> GetWeeklyStatsAsync(string userId);
        Task<MonthlyStatsDto> GetMonthlyStatsAsync(string userId);

        // PERSONAL RECORDS
        Task<List<PersonalRecordDto>> GetPersonalRecordsAsync(string userId);

        // GENERAL INSIGHTS
        Task<double> GetTotalCaloriesBurnedAsync(string userId);

        Task<int> GetTotalWorkoutsAsync(string userId);
    }
}