
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Helpers;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Middlewares;

namespace PatientManager.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IFileManager _fileManager;
        private readonly ValidateUserSession _validator;

        public PatientController(IPatientService patientService, IFileManager fileManager, ValidateUserSession validator)
        {
            _patientService = patientService;
            _fileManager = fileManager;
            _validator = validator;
        }

        // GET: PatientController
        public async Task<ActionResult> Index()
        {
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _patientService.Get());
        }

        // GET: PatientController/Create
        public ActionResult Create()
        {
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientSaveViewModel vm)
        {
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

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
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _patientService.GetById(id));
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PatientUpdateViewModel vm)
        {
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

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
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _patientService.GetById(id));
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, PatientUpdateViewModel vm)
        {
            if (!_validator.IsAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

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
