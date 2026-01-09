using Microsoft.AspNetCore.Mvc;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Repositories.Interfaces;
namespace TaskManagmentSystem.Controllers
{
    public class TimeLogController : Controller
    {
        private readonly ITimeLogRepository _timeLogService; 
        public TimeLogController(ITimeLogRepository TimeLogService)
        {
            _timeLogService = TimeLogService; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

        //public async Task<IActionResult> Store()

    }
}
