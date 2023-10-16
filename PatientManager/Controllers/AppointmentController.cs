using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.Patient;

namespace PatientManager.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly ILabTestService _labTestService;
        private readonly ILabReportService _labReportService;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IPatientService patientService, ILabTestService labTestService, ILabReportService labReportService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _patientService = patientService;
            _labTestService = labTestService;
            _labReportService = labReportService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _appointmentService.GetWithAll());
        }

        public async Task<ActionResult> Create()
        {
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
            return View(await _appointmentService.GetByIdWithAll(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Check(AppointmentViewModel vm)
        {
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
            return View(await _appointmentService.GetByIdWithAll(id));
        }

        public async Task<ActionResult> Delete(int id)
        {
            return View(await _appointmentService.GetByIdWithAll(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, AppointmentViewModel vm)
        {
            try
            {
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
