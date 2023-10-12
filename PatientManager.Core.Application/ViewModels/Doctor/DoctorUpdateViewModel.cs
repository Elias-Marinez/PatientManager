
using Microsoft.AspNetCore.Http;

namespace PatientManager.Core.Application.ViewModels.Doctor
{
    public class DoctorUpdateViewModel
    {
        public int DoctorId { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string PersonalID { get; set; }
        public string? ImageUrl { get; set; }

        public IFormFile? Image { get; set; }
    }
}
