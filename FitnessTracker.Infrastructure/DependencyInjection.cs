using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services;
        }
    }
}
