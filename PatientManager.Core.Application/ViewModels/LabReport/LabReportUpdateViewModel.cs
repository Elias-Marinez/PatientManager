
namespace PatientManager.Core.Application.ViewModels.LabReport
{
    public class LabReportUpdateViewModel
    {
        public int LabReportId { get; set; }
        public int AppointmentId { get; set; }
        public int LabTestId { get; set; }
        public required string Results { get; set; }
        public required string Status { get; set; }
    }
}
