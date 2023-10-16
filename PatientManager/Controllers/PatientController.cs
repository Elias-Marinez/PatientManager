
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Helpers;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using PatientManager.Core.Application.ViewModels.Patient;

namespace PatientManager.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IFileManager _fileManager;

        public PatientController(IPatientService patientService, IFileManager fileManager)
        {
            _patientService = patientService;
            _fileManager = fileManager;
        }

        // GET: PatientController
        public async Task<ActionResult> Index()
        {
            return View(await _patientService.Get());
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientSaveViewModel vm)
        {
            try
            {
                vm.ImageUrl = await _fileManager.Save(vm.Image, "patients");
                await _patientService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _patientService.GetById(id));
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PatientUpdateViewModel vm)
        {
            try
            {
                if (vm.Image != null)
                    vm.ImageUrl = await _fileManager.Update(vm.Image, "patients", vm.ImageUrl);

                await _patientService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _patientService.GetById(id));
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PatientUpdateViewModel vm)
        {
            try
            {
                vm = await _patientService.GetById(id);

                if (vm.ImageUrl != null)
                    _fileManager.Delete("patients", vm.ImageUrl);

                await _patientService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
