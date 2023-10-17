
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LabTest;
using PatientManager.Middlewares;

namespace PatientManager.Controllers
{
    public class LabTestController : Controller
    {
        private readonly ILabTestService _labTestService;
        private readonly ValidateUserSession _validator;


        public LabTestController(ILabTestService labTestService, ValidateUserSession validator)
        {
            _labTestService = labTestService;
            _validator = validator;
        }

        // GET: LabTestController
        public async Task<ActionResult> Index()
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _labTestService.Get());
        }

        // GET: LabTestController/Create
        public ActionResult Create()
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View();
        }

        // POST: LabTestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LabTestSaveViewModel vm)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _labTestService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabTestController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _labTestService.GetById(id));
        }

        // POST: LabTestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LabTestUpdateViewModel vm)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _labTestService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabTestController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _labTestService.GetById(id));
        }

        // POST: LabTestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, LabTestUpdateViewModel vm)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _labTestService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
