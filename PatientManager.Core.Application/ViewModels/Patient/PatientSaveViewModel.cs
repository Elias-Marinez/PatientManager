
using Microsoft.AspNetCore.Http;

namespace PatientManager.Core.Application.ViewModels.Patient
{
    public class PatientSaveViewModel
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string PersonalID { get; set; }
        public required DateOnly Birtday { get; set; }
        public bool Smoker { get; set; }
        public bool Allergies { get; set; }
        public string? ImageUrl { get; set; }

        public required IFormFile Image { get; set; }
    }
}
