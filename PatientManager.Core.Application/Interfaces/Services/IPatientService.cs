
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IPatientService : IGenericService<PatientViewModel,
                                                       PatientSaveViewModel,
                                                       PatientUpdateViewModel,
                                                       Patient>
    {

    }
}
