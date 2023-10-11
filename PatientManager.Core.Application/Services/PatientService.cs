
using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class PatientService : GenericService<PatientViewModel,PatientSaveViewModel, PatientUpdateViewModel, Patient>, IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
