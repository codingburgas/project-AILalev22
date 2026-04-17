using FitnessTracker.Application.DTOs.Workouts;
using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.WebHost.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly AppDbContext _context;

        public WorkoutService(AppDbContext context)
        {
            _context = context;
        }

        // Get all workouts for a user
        public async Task<List<WorkoutDto>> GetUserWorkoutsAsync(string userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .Select(w => new WorkoutDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Date = w.Date,

                    // LINQ + aggregation (important for grade)
                    TotalCalories = w.WorkoutExercises
                        .Sum(e => e.DurationMinutes * e.Exercise.CaloriesPerMinute)
                })
                .ToListAsync();
        }

        // Get workout details
        public async Task<WorkoutDetailsDto> GetWorkoutByIdAsync(int id)
        {
            var workout = await _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
                throw new Exception("Workout not found");

            return new WorkoutDetailsDto
            {
                Id = workout.Id,
                Name = workout.Name,
                Date = workout.Date,
                Exercises = workout.WorkoutExercises
                    .Select(e => new WorkoutExerciseDto
                    {
                        ExerciseName = e.Exercise.Name,
                        Sets = e.Sets,
                        Reps = e.Reps,
                        DurationMinutes = e.DurationMinutes,
                        Intensity = e.Intensity.ToString(),

                        // calories calculation
                        CaloriesBurned = e.DurationMinutes * e.Exercise.CaloriesPerMinute
                    })
                    .ToList()
            };
        }

        // Create workout
        public async Task CreateWorkoutAsync(CreateWorkoutDto dto, string userId)
        {
            var workout = new Workout
            {
                Name = dto.Name,
                Date = dto.Date,
                UserId = userId
            };

            await _context.Workouts.AddAsync(workout);
            await _context.SaveChangesAsync();
        }

        // Update workout
        public async Task UpdateWorkoutAsync(int id, EditWorkoutDto dto)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
                throw new Exception("Workout not found");

            workout.Name = dto.Name;
            workout.Date = dto.Date;

            await _context.SaveChangesAsync();
        }

        // Delete workout
        public async Task DeleteWorkoutAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
                throw new Exception("Workout not found");

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
        }

        public async Task AddExerciseToWorkoutAsync(int workoutId, AddExerciseToWorkoutDto dto)
        {
            Console.WriteLine("ID {0}", workoutId);

            var workout = await _context.Workouts
                .Include(w => w.WorkoutExercises)
                .FirstOrDefaultAsync(w => w.Id == workoutId);

            if (workout == null)
                throw new Exception("Workout not found");

            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(e => e.Id == dto.ExerciseId);

            if (exercise == null)
                throw new Exception("Exercise not found");

            var workoutExercise = new WorkoutExercise
            {
                WorkoutId = workoutId,
                ExerciseId = dto.ExerciseId,
                Sets = dto.Sets,
                Reps = dto.Reps,
                DurationMinutes = dto.DurationMinutes,
                Intensity = Enum.Parse<IntensityLevel>(dto.Intensity)
            };

            _context.WorkoutExercises.Add(workoutExercise);
            await _context.SaveChangesAsync();
        }
    }
}
