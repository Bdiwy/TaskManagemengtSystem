using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Controllers
{
    public class TimeLogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITimeLogRepository _timeLogService;
        
        public TimeLogController(ITimeLogRepository TimeLogService, AppDbContext context)
        {
            _timeLogService = TimeLogService;
            _context = context;
        }

        public IActionResult Index() => View();
        
        public IActionResult Show() => View();

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateTaskListAsync();
            return View("Add");
        }

        public IActionResult Update() => View();
        
        public IActionResult Delete() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(TimeLogViewModel request)
        {
            if (request.TaskId > 0 && !await _context.TaskLists.AnyAsync(t => t.Id == request.TaskId))
                ModelState.AddModelError(nameof(request.TaskId), "Selected task does not exist");

            if (!ModelState.IsValid)
            {
                await PopulateTaskListAsync();
                return View("Add", request);
            }

            var result = await _timeLogService.CreateAsync(new TimeLogViewModel
            {
                Actul = request.Actul,
                Allocat = request.Allocat,
                Progress = request.Progress,
                TaskId = request.TaskId
            });

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                await PopulateTaskListAsync();
                return View("Add", request);
            }

            return RedirectToAction("Show");
        }

        public async Task<IActionResult> Update(TimeLogViewModel timeLogFromRequest)
        {
            await _timeLogService.UpdateAsync(timeLogFromRequest);
            return RedirectToAction("Show", new { Id = timeLogFromRequest.Id });
        }

        private async Task PopulateTaskListAsync()
        {
            ViewBag.TaskList = new SelectList(
                await _context.TaskLists
                    .Select(t => new { t.Id, t.Title })
                    .ToListAsync(),
                "Id",
                "Title"
            );
        }
    }
}
