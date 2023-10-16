
using PatientManager.Core.Application.ViewModels.LabTest;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class AppointmentConsultViewModel
    {
        public int AppointmentId { get; set; }
        public IEnumerable<LabTestViewModel>? LabTests { get; set; }
        public List<int>? SelectedLabTest { get; set; }
    }
}
