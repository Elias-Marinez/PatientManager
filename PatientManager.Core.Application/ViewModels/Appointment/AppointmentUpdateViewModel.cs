
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class AppointmentUpdateViewModel
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un paciente")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un doctor")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una fecha y hora")]
        [DataType(DataType.DateTime)]
        public required DateTime Date { get; set; }

        [Required(ErrorMessage = "Debe colocar la causa")]
        [DataType(DataType.Text)]
        public required string Reason { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public required string Status { get; set; }
    }
}
