using FitnessTracker.Application.DTOs.Statistics;
using FitnessTracker.Application.Interfaces;
using FitnessTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Application.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly AppDbContext _context;

        public StatisticsService(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // WEEKLY STATS
        // =========================
        public async Task<WeeklyStatsDto> GetWeeklyStatsAsync(string userId)
        {
            var weekStart = DateTime.UtcNow.AddDays(-7);

            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId && w.Date >= weekStart)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .ToListAsync();

            var totalCalories = workouts
                .SelectMany(w => w.WorkoutExercises)
                .Sum(e => e.DurationMinutes * e.Exercise.CaloriesPerMinute);

            var totalMinutes = workouts
                .SelectMany(w => w.WorkoutExercises)
                .Sum(e => e.DurationMinutes);

            return new WeeklyStatsDto
            {
                TotalCalories = totalCalories,
                TotalWorkouts = workouts.Count,
                TotalMinutes = totalMinutes
            };
        }

        // =========================
        // MONTHLY STATS
        // =========================
        public async Task<MonthlyStatsDto> GetMonthlyStatsAsync(string userId)
        {
            var monthStart = DateTime.UtcNow.AddDays(-30);

            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId && w.Date >= monthStart)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .ToListAsync();

            var totalCalories = workouts
                .SelectMany(w => w.WorkoutExercises)
                .Sum(e => e.DurationMinutes * e.Exercise.CaloriesPerMinute);

            var totalMinutes = workouts
                .SelectMany(w => w.WorkoutExercises)
                .Sum(e => e.DurationMinutes);

            return new MonthlyStatsDto
            {
                TotalCalories = totalCalories,
                TotalWorkouts = workouts.Count,
                TotalMinutes = totalMinutes
            };
        }

        // =========================
        // DAILY ACTIVITY (FOR CHART)
        // =========================
        public async Task<List<DailyActivityDto>> GetDailyActivityAsync(string userId)
        {
            var last30Days = DateTime.UtcNow.AddDays(-30);

            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId && w.Date >= last30Days)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .ToListAsync();

            var grouped = workouts
                .GroupBy(w => w.Date.Date)
                .Select(g => new DailyActivityDto
                {
                    Date = g.Key,
                    Calories = g.SelectMany(w => w.WorkoutExercises)
                        .Sum(e => e.DurationMinutes * e.Exercise.CaloriesPerMinute),
                    Minutes = g.SelectMany(w => w.WorkoutExercises)
                        .Sum(e => e.DurationMinutes)
                })
                .OrderBy(x => x.Date)
                .ToList();

            return grouped;
        }

        // =========================
        // PERSONAL RECORDS
        // =========================
        public async Task<List<ExerciseRecordDto>> GetPersonalRecordsAsync(string userId)
        {
            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .ToListAsync();

            var records = workouts
                .SelectMany(w => w.WorkoutExercises)
                .GroupBy(e => e.Exercise.Name)
                .Select(g => new ExerciseRecordDto
                {
                    ExerciseName = g.Key,
                    BestReps = g.Max(x => x.Reps),
                    BestSets = g.Max(x => x.Sets),
                    MaxDuration = g.Max(x => x.DurationMinutes)
                })
                .ToList();

            return records;
        }
    }
}