
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LabReport;
using PatientManager.Middlewares;

namespace PatientManager.Controllers
{
    public class LabReportController : Controller
    {
        private readonly ILabReportService _labReportService;
        private readonly ValidateUserSession _validator;

        public LabReportController(ILabReportService labReportService, ValidateUserSession validator)
        {
            _labReportService = labReportService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _labReportService.GetWithAll());
        }

        public async Task<ActionResult> Report(int id)
        {
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _labReportService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Report(int id, LabReportUpdateViewModel vm)
        {
            try
            {
                if (!_validator.IsAsistent())
                    return RedirectToRoute(new { controller = "Home", action = "Index" });

                await _labReportService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
