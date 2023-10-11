
namespace PatientManager.Core.Domain.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        public required string Reason { get; set; }
        public required string Status { get; set; }

        // Navegation Property
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public ICollection<LabReport>? LabReports { get; set; }
    }
}
