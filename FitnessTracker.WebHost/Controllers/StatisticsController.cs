using FitnessTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessTracker.WebHost.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }

        // Dashboard (Graph page)
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var data = await _statisticsService.GetDailyActivityAsync(userId);

            return View(data);
        }

        // Weekly stats page
        public async Task<IActionResult> Weekly()
        {
            var userId = GetUserId();

            var stats = await _statisticsService.GetWeeklyStatsAsync(userId);

            return View(stats);
        }

        // Monthly stats page
        public async Task<IActionResult> Monthly()
        {
            var userId = GetUserId();

            var stats = await _statisticsService.GetMonthlyStatsAsync(userId);

            return View(stats);
        }

        // Personal records page
        public async Task<IActionResult> Records()
        {
            var userId = GetUserId();

            var records = await _statisticsService.GetPersonalRecordsAsync(userId);

            return View(records);
        }
    }
}