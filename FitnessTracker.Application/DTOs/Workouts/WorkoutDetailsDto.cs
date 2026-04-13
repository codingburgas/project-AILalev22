using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.DTOs.Workouts
{
    public class WorkoutDetailsDto
    {
        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; } = new();
    }
}
