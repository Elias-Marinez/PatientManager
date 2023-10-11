
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.LabReport;
using PatientManager.Core.Application.ViewModels.Patient;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public required string Reason { get; set; }
        public required string Status { get; set; }

        // Navegation Property
        public PatientViewModel? Patient { get; set; }
        public DoctorViewModel? Doctor { get; set; }
        public IEnumerable<LabReportViewModel>? LabReports { get; set; }
    }
}
