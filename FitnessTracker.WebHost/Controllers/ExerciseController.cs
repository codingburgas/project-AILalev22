using FitnessTracker.Application.DTOs.Exercises;
using FitnessTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.WebHost.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _Exerciseervice;

        public ExerciseController(IExerciseService Exerciseervice)
        {
            _Exerciseervice = Exerciseervice;
        }

        // GET: /Exercise
        public async Task<IActionResult> Index()
        {
            var Exercise = await _Exerciseervice.GetAllAsync();
            return View(Exercise);
        }

        // GET: /Exercise/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var exercise = await _Exerciseervice.GetByIdAsync(id);
            return View(exercise);
        }

        // GET: /Exercise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Exercise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExerciseDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _Exerciseervice.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Exercise/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var exercise = await _Exerciseervice.GetByIdAsync(id);

            var dto = new EditExerciseDto
            {
                Name = exercise.Name,
                Type = exercise.Type,
                CaloriesPerMinute = exercise.CaloriesPerMinute
            };

            return View(dto);
        }

        // POST: /Exercise/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditExerciseDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _Exerciseervice.UpdateAsync(id, dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Exercise/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var exercise = await _Exerciseervice.GetByIdAsync(id);
            return View(exercise);
        }

        // POST: /Exercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Exerciseervice.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}