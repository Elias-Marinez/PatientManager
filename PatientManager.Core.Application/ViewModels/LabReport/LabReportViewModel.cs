
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.LabTest;

namespace PatientManager.Core.Application.ViewModels.LabReport
{
    public class LabReportViewModel
    {
        public int LabReportId { get; set; }
        public int AppointmentId { get; set; }
        public int LabTestId { get; set; }
        public string? Results { get; set; }
        public required string Status { get; set; }

        // Navegation Property
        public AppointmentViewModel? Appointment { get; set; }
        public LabTestViewModel? LabTest { get; set; }
    }
}
