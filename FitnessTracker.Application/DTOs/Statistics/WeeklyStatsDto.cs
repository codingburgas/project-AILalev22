using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.DTOs.Statistics
{
    public class WeeklyStatsDto
    {
        public double TotalCalories { get; set; }
        public int TotalWorkouts { get; set; }
        public int TotalMinutes { get; set; }
    }
}