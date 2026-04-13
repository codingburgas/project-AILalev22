using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Application.DTOs.Workouts
{
    public class EditWorkoutDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }
    }
}