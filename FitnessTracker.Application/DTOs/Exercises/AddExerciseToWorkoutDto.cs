using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.DTOs.Workouts
{
    public class AddExerciseToWorkoutDto
    {
        public int ExerciseId { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public int DurationMinutes { get; set; }

        public string Intensity { get; set; } = null!;
    }
}