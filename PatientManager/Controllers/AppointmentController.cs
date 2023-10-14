using Microsoft.AspNetCore.Mvc;

namespace PatientManager.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
