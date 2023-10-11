
using PatientManager.Core.Application.ViewModels.LabTest;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface ILabTestService : IGenericService<LabTestViewModel,
                                                       LabTestSaveViewModel,
                                                       LabTestUpdateViewModel,
                                                       LabTest>
    {

    }
}
