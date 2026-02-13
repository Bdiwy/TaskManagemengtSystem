using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.Srvices.Interfaces;

namespace TaskManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnalysisService _analysisService;

        public HomeController(ILogger<HomeController> logger , IAnalysisService analysisService)
        {
            _logger = logger;
            _analysisService = analysisService;
        }

        public IActionResult Index()
        {
            var analysis = _analysisService.GetAnalysisAsync().Result;
            return View(analysis);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
