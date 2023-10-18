﻿
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.Doctor
{
    public class DoctorUpdateViewModel
    {
        [Required]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar un apellido")]
        [DataType(DataType.Text)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Debe colocar un correo")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar un numero telefonico")]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Debe colocar su numero de identificación personal")]
        [DataType(DataType.Text)]
        public required string PersonalID { get; set; }

        public required string ImageUrl { get; set; }

        public IFormFile? Image { get; set; }
    }
}
