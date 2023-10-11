
using PatientManager.Core.Application.ViewModels.LabReport;

namespace PatientManager.Core.Application.ViewModels.LabTest
{
    public class LabTestViewModel
    {
        public int LabTestId { get; set; }
        public required string Name { get; set; }

        // Navegation Property
        public ICollection<LabReportViewModel>? LabReports { get; set; }
    }
}
