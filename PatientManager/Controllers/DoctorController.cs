
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Helpers;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Middlewares;

namespace PatientManager.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IFileManager _fileManager;
        private readonly ValidateUserSession _validator;

        public DoctorController(IDoctorService doctorService, IFileManager fileManager, ValidateUserSession validator)
        {
            _doctorService = doctorService;
            _fileManager = fileManager;
            _validator = validator;
        }

        // GET: DoctorController
        public async Task<ActionResult> Index()
        {
            if (!_validator.IsAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _doctorService.Get());
        }

        // GET: DoctorController/Create
        public ActionResult Create()
        {
            if (!_validator.IsAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View();
        }

        // POST: DoctorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DoctorSaveViewModel vm)
        {
            if (!_validator.IsAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                vm.ImageUrl = await _fileManager.Save(vm.Image, "doctors");
                await _doctorService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (!_validator.IsAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _doctorService.GetById(id));
        }

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DoctorUpdateViewModel vm)
        {
            if (!_validator.IsAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                if(vm.Image != null)
                    vm.ImageUrl = await _fileManager.Update(vm.Image, "doctors", vm.ImageUrl);

                await _doctorService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (!_validator.IsAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _doctorService.GetById(id));
        }

        // POST: DoctorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, DoctorUpdateViewModel vm)
        {
            if (!_validator.IsAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                vm = await _doctorService.GetById(id);

                if (vm.ImageUrl != null)
                    _fileManager.Delete("doctors", vm.ImageUrl);

                await _doctorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
