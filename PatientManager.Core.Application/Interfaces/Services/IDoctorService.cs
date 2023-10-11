
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IDoctorService : IGenericService<DoctorViewModel, 
                                                      DoctorSaveViewModel,
                                                      DoctorUpdateViewModel,
                                                      Doctor>
    {

    }
}
