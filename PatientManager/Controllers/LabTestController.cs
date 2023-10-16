
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LabTest;

namespace PatientManager.Controllers
{
    public class LabTestController : Controller
    {
        private readonly ILabTestService _labTestService;

        public LabTestController(ILabTestService labTestService)
        {
            _labTestService = labTestService;
        }

        // GET: LabTestController
        public async Task<ActionResult> Index()
        {
            return View(await _labTestService.Get());
        }

        // GET: LabTestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LabTestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LabTestSaveViewModel vm)
        {
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
            return View(await _labTestService.GetById(id));
        }

        // POST: LabTestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LabTestUpdateViewModel vm)
        {
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
            return View(await _labTestService.GetById(id));
        }

        // POST: LabTestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, LabTestUpdateViewModel vm)
        {
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
