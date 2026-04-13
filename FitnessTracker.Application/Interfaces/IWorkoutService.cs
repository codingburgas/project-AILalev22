using System;
using System.Collections.Generic;
using System.Text;
using FitnessTracker.Application.DTOs.Workouts;

namespace FitnessTracker.Application.Interfaces
{
    public interface IWorkoutService
    {
        Task<List<WorkoutDto>> GetUserWorkoutsAsync(string userId);
        Task<WorkoutDetailsDto> GetWorkoutByIdAsync(int id);
        Task CreateWorkoutAsync(CreateWorkoutDto dto, string userId);
        Task UpdateWorkoutAsync(int id, EditWorkoutDto dto);
        Task DeleteWorkoutAsync(int id);
    }
}
