
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Repository
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<Appointment> GetByIdWithAll(int id);
    }
}
