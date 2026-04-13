using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.DTOs.Exercises
{
    public class ExerciseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;

        public double CaloriesPerMinute { get; set; }
    }
}