
using System.ComponentModel.DataAnnotations;

namespace PatientManager.Core.Application.ViewModels.LabTest
{
    public class LabTestSaveViewModel
    {
        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public required string Name { get; set; }
    }
}
