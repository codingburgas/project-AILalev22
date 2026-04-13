using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application.DTOs.Statistics
{
    public class ExerciseRecordDto
    {
        public string ExerciseName { get; set; } = null!;
        public int BestReps { get; set; }
        public int BestSets { get; set; }
        public int MaxDuration { get; set; }
    }
}
