
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Middlewares;

namespace PatientManager.Controllers
{
    public class AppointmentController : Controller
    {
        #region Dependencies
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly ILabTestService _labTestService;
        private readonly ILabReportService _labReportService;
        private readonly ValidateUserSession _validator;
        #endregion

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService, ILabTestService labTestService, ILabReportService labReportService, ValidateUserSession validator)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
            _labTestService = labTestService;
            _labReportService = labReportService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _appointmentService.GetWithAll());
        }

        public async Task<ActionResult> Create()
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            AppointmentSaveViewModel vm = new()
            {
                Patients = await _patientService.Get(),
                Doctors = await _doctorService.Get()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AppointmentSaveViewModel vm)
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _appointmentService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Consult(int id)
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            AppointmentConsultViewModel vm = new()
            {
                AppointmentId = id,
                LabTests = await _labTestService.Get()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Consult(AppointmentConsultViewModel vm)
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _labReportService.AddByAppointment(vm);
                await _appointmentService.StatusUpdate(vm.AppointmentId, 1);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Check(int id)
        {
            if(!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _appointmentService.GetByIdWithAll(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Check(AppointmentViewModel vm)
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _appointmentService.StatusUpdate(vm.AppointmentId, 2);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Results(int id)
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _appointmentService.GetByIdWithAll(id));
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (!_validator.isAsistent())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _appointmentService.GetByIdWithAll(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, AppointmentViewModel vm)
        {
            try
            {
                if (!_validator.isAsistent())
                    return RedirectToRoute(new { controller = "Home", action = "Index" });

                await _appointmentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
