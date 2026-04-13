using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.DTOs.Workouts
{
    public class WorkoutDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public double TotalCalories { get; set; }
    }
}