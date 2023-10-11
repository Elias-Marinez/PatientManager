
namespace PatientManager.Core.Domain.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public required string Name { get; set; }
        public required string LastName {  get; set; }
        public required string Email { get; set;}
        public required string Phone { get; set; }
        public required string PersonalID { get; set;}
        public required string ImageUrl { get; set; }

        // Navegation Property
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
