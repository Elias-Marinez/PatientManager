
using PatientManager.Core.Application.ViewModels.Appointment;

namespace PatientManager.Core.Application.ViewModels.Patient
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string PersonalID { get; set; }
        public required DateOnly Birtday { get; set; }
        public bool Smoker { get; set; }
        public bool Allergies { get; set; }
        public required string ImageUrl { get; set; }
        public IEnumerable<AppointmentViewModel>? Appointments { get; set; }
    }
}
