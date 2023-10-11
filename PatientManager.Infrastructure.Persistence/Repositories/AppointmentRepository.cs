
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infrastructure.Persistence.Contexts;

namespace PatientManager.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationContext _dbContext;

        public AppointmentRepository(ApplicationContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
