using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using PatientManager.Core.Application.ViewModels.LabReport;
using PatientManager.Core.Application.ViewModels.LabTest;

namespace PatientManager.Controllers
{
    public class LabReportController : Controller
    {
        private readonly ILabReportService _labReportService;

        public LabReportController(ILabReportService labReportService)
        {
            _labReportService = labReportService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _labReportService.GetWithAll());
        }

        public async Task<ActionResult> Report(int id)
        {
            return View(await _labReportService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Report(int id, LabReportUpdateViewModel vm)
        {
            try
            {
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
