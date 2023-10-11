
using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class AppointmentService : GenericService<AppointmentViewModel, AppointmentSaveViewModel, AppointmentUpdateViewModel, Appointment>, IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
