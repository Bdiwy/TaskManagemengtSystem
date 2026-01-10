using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
using TaskManagmentSystem.Srvices.Interfaces;
using TaskManagmentSystem.ViewModels;

namespace TaskManagmentSystem.Controllers
{
    public class TimeLogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITimeLogService _timeLogService;
        
        public TimeLogController(ITimeLogService TimeLogService, AppDbContext context)
        {
            _timeLogService = TimeLogService;
            _context = context;
        }

        public IActionResult Index() => View();
        
        public async Task<IActionResult> Show()
        {
            var result = await _timeLogService.GetAllAsync();

            if (!result.Succeeded)
                return View();
            return View(result.Data);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateUserTasksAsync();
            return View("Add");
        }

        public IActionResult Update() => View();
        
        public IActionResult Delete() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(TimeLogViewModel request)
        {
            if (request.TaskId > 0 && !await _context.UserTasks.AnyAsync(t => t.Id == request.TaskId))
                ModelState.AddModelError(nameof(request.TaskId), "Selected task does not exist");

            if (!ModelState.IsValid)
            {
                await PopulateUserTasksAsync();
                return View("Add", request);
            }

            var result = await _timeLogService.CreateAsync(new TimeLogViewModel
            {
                Actul = request.Actul,
                Allocat = request.Allocat,
                Progress = request.Progress,
                TaskId = request.TaskId,
                UserId =  User.FindFirstValue(ClaimTypes.NameIdentifier)
            });

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                await PopulateUserTasksAsync();
                return View("Add", request);
            }

            return RedirectToAction("Show");
        }

        public async Task<IActionResult> Update(TimeLogViewModel timeLogFromRequest)
        {
            await _timeLogService.UpdateAsync(timeLogFromRequest);
            return RedirectToAction("Show", new { Id = timeLogFromRequest.Id });
        }

        private async Task PopulateUserTasksAsync()
        {
            ViewBag.TaskList = new SelectList(
                await _context.UserTasks
                    .Select(t => new { t.Id, t.Title })
                    .ToListAsync(),
                "Id",
                "Title"
            );
        }
    }
}
