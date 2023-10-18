
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.LabReport
{
    public class LabReportSaveViewModel
    {
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int LabTestId { get; set; }
        public string? Results { get; set; }
        public required string Status { get; set; }
    }
}
