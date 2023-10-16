
using Microsoft.AspNetCore.Http;

namespace PatientManager.Core.Application.ViewModels.Patient
{
    public class PatientUpdateViewModel
    {
        public int PatientId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string PersonalID { get; set; }
        public DateOnly Birtday { get; set; }
        public bool Smoker { get; set; }
        public bool Allergies { get; set; }
        public required string ImageUrl { get; set; }

        public IFormFile? Image { get; set; }
    }
}
