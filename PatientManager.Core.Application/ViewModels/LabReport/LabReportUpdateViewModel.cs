
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.LabReport
{
    public class LabReportUpdateViewModel
    {
        [Required]
        public int LabReportId { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int LabTestId { get; set; }

        [Required(ErrorMessage = "Debe introducir los resultados")]
        public required string Results { get; set; }
        [Required]
        public required string Status { get; set; }
    }
}
