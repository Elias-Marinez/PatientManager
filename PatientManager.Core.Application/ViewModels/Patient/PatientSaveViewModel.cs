
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.Patient
{
    public class PatientSaveViewModel
    {
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
        public required DateOnly Birtday { get; set; }
        public bool Smoker { get; set; }
        public bool Allergies { get; set; }
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Debe insertar una foto")]
        [DataType(DataType.Upload)]
        public required IFormFile Image { get; set; }
    }
}
