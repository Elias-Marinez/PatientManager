
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.Patient
{
    public class PatientUpdateViewModel
    {
        [Required]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar un apellido")]
        [DataType(DataType.Text)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Debe colocar un numero telefonico")]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Debe colocar su direccion")]
        [DataType(DataType.Text)]
        public required string Address { get; set; }

        [Required(ErrorMessage = "Debe colocar su numero de identificación personal")]
        [DataType(DataType.Text)]
        public required string PersonalID { get; set; }

        [Required(ErrorMessage = "Debe colocar su fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateOnly Birtday { get; set; }
        public bool Smoker { get; set; }
        public bool Allergies { get; set; }
        public required string ImageUrl { get; set; }

        public IFormFile? Image { get; set; }
    }
}
