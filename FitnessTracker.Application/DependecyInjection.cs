using FitnessTracker.Application.Interfaces;
using FitnessTracker.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService,AuthService>();

            services.AddScoped<IExerciseService,ExerciseService>();

            services.AddScoped<IStatisticsService,StatisticsService>();

            services.AddScoped<IWorkoutService,WorkoutService>();

            return services;
        }
    }
}
