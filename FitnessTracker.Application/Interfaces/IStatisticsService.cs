using FitnessTracker.Application.DTOs.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.Interfaces
{
    public interface IStatisticsService
    {
        Task<WeeklyStatsDto> GetWeeklyStatsAsync(string userId);

        Task<MonthlyStatsDto> GetMonthlyStatsAsync(string userId);

        Task<List<DailyActivityDto>> GetDailyActivityAsync(string userId);

        Task<List<ExerciseRecordDto>> GetPersonalRecordsAsync(string userId);
    }
}