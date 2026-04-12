using FitnessTracker.Application.DTOs.Workouts;

namespace FitnessTracker.Application.Interfaces
{
    public interface IWorkoutService
    {
        // CREATE
        Task<int> CreateWorkoutAsync(string userId, CreateWorkoutDto dto);

        // READ
        Task<List<WorkoutDto>> GetUserWorkoutsAsync(string userId);
        Task<WorkoutDetailsDto?> GetWorkoutByIdAsync(int workoutId, string userId);

        // UPDATE
        Task<bool> UpdateWorkoutAsync(string userId, UpdateWorkoutDto dto);

        // DELETE
        Task<bool> DeleteWorkoutAsync(int workoutId, string userId);

        // BUSINESS LOGIC
        Task<bool> AddExerciseToWorkoutAsync(AddExerciseToWorkoutDto dto);
        Task<bool> RemoveExerciseFromWorkoutAsync(int workoutId, int exerciseId);

        // CALORIES
        Task<double> CalculateWorkoutCaloriesAsync(int workoutId);
    }
}