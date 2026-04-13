using FitnessTracker.Application.DTOs.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.Interfaces
{
    public interface IExerciseService
    {
        Task<List<ExerciseDto>> GetAllAsync();

        Task<ExerciseDto> GetByIdAsync(int id);

        Task CreateAsync(CreateExerciseDto dto);

        Task UpdateAsync(int id, EditExerciseDto dto);

        Task DeleteAsync(int id);
    }
}