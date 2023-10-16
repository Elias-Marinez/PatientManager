
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

        public async Task<AppointmentViewModel> GetByIdWithAll(int id)
        {
            var entity = await _repository.GetByIdWithAll(id);
            AppointmentViewModel vm = _mapper.Map<AppointmentViewModel>(entity);
            return vm;
        }

        public async Task StatusUpdate(int id, int state)
        {
            var entity = await this.GetById(id);
            switch (state)
            {
                case 1:
                    entity.Status = "Resultados";
                    break;
                case 2:
                    entity.Status = "Completada";
                    break;
                default:
                    entity.Status = "Consulta";
                    break;

            }

            await this.Update(entity, id);
        }
    }
}
