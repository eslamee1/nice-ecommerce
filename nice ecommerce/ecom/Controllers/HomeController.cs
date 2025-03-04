using ecom.Data;
using ecom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ecom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger) 
        {
            _logger = logger;
        }

        public string text ()
        {
            return "kdjnf";
        }

        public IActionResult Index()
        {
            return View();
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
