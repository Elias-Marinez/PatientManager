
namespace PatientManager.Core.Application.ViewModels.LabReport
{
    public class LabReportSaveViewModel
    {
        public int AppointmentId { get; set; }
        public int LabTestId { get; set; }
        public string? Results { get; set; }
        public required string Status { get; set; }
    }
}
