
namespace PatientManager.Core.Domain.Entities
{
    public class LabTest
    {
        public int LabTestId { get; set; }
        public required string Name { get; set; }

        // Navegation Property
        public ICollection<LabReport>? LabReports { get; set; }
    }
}
