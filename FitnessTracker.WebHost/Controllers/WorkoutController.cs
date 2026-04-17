using FitnessTracker.Application.DTOs.Workouts;
using FitnessTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessTracker.WebHost.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;
        private readonly IExerciseService _exerciseService;
        public WorkoutController(IWorkoutService workoutService, IExerciseService exerciseService)
        {
            _workoutService = workoutService;
            _exerciseService = exerciseService;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }

        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var workouts = await _workoutService.GetUserWorkoutsAsync(userId);

            return View(workouts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);

            return View(workout);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateWorkoutDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var userId = GetUserId();

            await _workoutService.CreateWorkoutAsync(dto, userId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);

            var dto = new EditWorkoutDto
            {
                Name = workout.Name,
                Date = workout.Date
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditWorkoutDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _workoutService.UpdateWorkoutAsync(id, dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);

            return View(workout);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _workoutService.DeleteWorkoutAsync(id);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddExercise(int id)
        {
            ViewBag.WorkoutId = id;
            ViewBag.Exercises = await _exerciseService.GetAllAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExercise(int id, AddExerciseToWorkoutDto dto)
        {

            Console.WriteLine("Controller ID {0}", id);

            await _workoutService.AddExerciseToWorkoutAsync(id, dto);

            return RedirectToAction("Details", new { id });
        }
    }
}