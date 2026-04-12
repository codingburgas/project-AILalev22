using FitnessTracker.Application.DTOs.Exercises;

namespace FitnessTracker.Application.Interfaces
{
    public interface IExerciseService
    {
        // CREATE (Admin only)
        Task<int> CreateExerciseAsync(CreateExerciseDto dto);

        // READ
        Task<List<ExerciseDto>> GetAllExercisesAsync();
        Task<ExerciseDto?> GetExerciseByIdAsync(int id);

        // UPDATE (Admin only)
        Task<bool> UpdateExerciseAsync(int id, CreateExerciseDto dto);

        // DELETE (Admin only)
        Task<bool> DeleteExerciseAsync(int id);
    }
}