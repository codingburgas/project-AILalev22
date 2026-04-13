using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Application.DTOs.Exercises
{
    public class CreateExerciseDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [Range(0.1, 1000)]
        public double CaloriesPerMinute { get; set; }
    }
}