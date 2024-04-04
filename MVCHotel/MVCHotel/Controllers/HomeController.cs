using Microsoft.AspNetCore.Mvc;
using MVCHotel.Models;
using System.Diagnostics;

namespace MVCHotel.Controllers
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
            Cliente cliente = new Cliente();

            cliente.Id = 1;
            cliente.Name = "Adrian";
            cliente.Email = "adrian@gmail.com";

            ViewBag.Id = cliente.Id;
            ViewBag.Name = cliente.Name;
            ViewBag.Email = cliente.Email;

            return View();
        }

        public IActionResult Contact() { 
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