using Microsoft.AspNetCore.Mvc;

namespace PatientManager.Controllers
{
    public class LabReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
