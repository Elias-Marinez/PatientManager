
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.Patient;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class AppointmentSaveViewModel
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public IEnumerable<PatientViewModel>? Patients { get; set; }
        public IEnumerable<DoctorViewModel>? Doctors { get; set; }
    }
}
