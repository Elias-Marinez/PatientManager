
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.Patient;
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class AppointmentSaveViewModel
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una fecha y hora")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Debe colocar la causa")]
        [DataType(DataType.Text)]
        public string Reason { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Status { get; set; }
        public IEnumerable<PatientViewModel>? Patients { get; set; }
        public IEnumerable<DoctorViewModel>? Doctors { get; set; }
    }
}
