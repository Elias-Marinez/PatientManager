
namespace PatientManager.Core.Application.ViewModels.Appointment
{
    public class AppointmentSaveViewModel
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public required string Reason { get; set; }
        public required string Status { get; set; }
    }
}
