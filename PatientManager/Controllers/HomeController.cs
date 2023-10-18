using Microsoft.AspNetCore.Mvc;
using PatientManager.Middlewares;
using PatientManager.Models;
using System.Diagnostics;

namespace PatientManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validator;


        public HomeController(ILogger<HomeController> logger, ValidateUserSession validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public IActionResult Index()
        {
            if (!_validator.IsLogged())
                return RedirectToRoute(new { controller = "User", action = "Login" });

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}