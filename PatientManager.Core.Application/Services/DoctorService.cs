
using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class DoctorService : GenericService<DoctorViewModel, DoctorSaveViewModel, DoctorUpdateViewModel, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository repository, IMapper mapper) :base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
