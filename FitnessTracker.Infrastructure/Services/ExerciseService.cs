using FitnessTracker.Application.DTOs.Exercises;
using FitnessTracker.Application.Interfaces;
using FitnessTracker.Domain.Entities;
using FitnessTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly AppDbContext _context;

        public ExerciseService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<ExerciseDto>> GetAllAsync()
        {
            return await _context.Exercises
                .Select(e => new ExerciseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.Type,
                    CaloriesPerMinute = e.CaloriesPerMinute
                })
                .ToListAsync();
        }

        // GET BY ID
        public async Task<ExerciseDto> GetByIdAsync(int id)
        {
            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
                throw new Exception("Exercise not found");

            return new ExerciseDto
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Type = exercise.Type,
                CaloriesPerMinute = exercise.CaloriesPerMinute
            };
        }

        // CREATE
        public async Task CreateAsync(CreateExerciseDto dto)
        {
            var exercise = new Exercise
            {
                Name = dto.Name,
                Type = dto.Type,
                CaloriesPerMinute = dto.CaloriesPerMinute
            };

            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateAsync(int id, EditExerciseDto dto)
        {
            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
                throw new Exception("Exercise not found");

            exercise.Name = dto.Name;
            exercise.Type = dto.Type;
            exercise.CaloriesPerMinute = dto.CaloriesPerMinute;

            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
                throw new Exception("Exercise not found");

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}