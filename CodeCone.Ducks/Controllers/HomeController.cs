using CodeCone.Ducks.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using CodeCone.Ducks.Data;
using System.Diagnostics;


namespace CodeCone.Ducks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Json(null);
        }

        public IActionResult Privacy()
        {
            return Json(null);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Json(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
