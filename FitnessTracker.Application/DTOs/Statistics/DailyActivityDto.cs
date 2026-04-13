using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.DTOs.Statistics
{
    public class DailyActivityDto
    {
        public DateTime Date { get; set; }
        public double Calories { get; set; }
        public int Minutes { get; set; }
    }
}
