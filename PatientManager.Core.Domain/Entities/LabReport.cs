
namespace PatientManager.Core.Domain.Entities
{
    public class LabReport
    {
        public int LabReportId { get; set; }
        public int AppointmentId {  get; set; }
        public int LabTestId {  get; set; }
        public string? Results { get; set; }
        public required string Status { get; set; }

        // Navegation Property
        public Appointment? Appointment { get; set; }
        public LabTest? LabTest { get; set; }
    }
}
