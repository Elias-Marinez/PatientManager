
using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.LabTest;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class LabTestService : GenericService<LabTestViewModel, LabTestSaveViewModel, LabTestUpdateViewModel, LabTest>, ILabTestService
    {
        private readonly ILabTestRepository _repository;
        private readonly IMapper _mapper;

        public LabTestService(ILabTestRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
