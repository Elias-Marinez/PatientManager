
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.User
{
    public class UserSaveViewModel
    {

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar un apellido")]
        [DataType(DataType.Text)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Debe colocar un correo")]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre de usuario")]
        [DataType(DataType.Text)]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coiciden")]
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        public required string UserType { get; set; }
    }
}
