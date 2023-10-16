
using Microsoft.EntityFrameworkCore;
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

        public async Task<Appointment> GetByIdWithAll(int id)
        {
            return await _dbContext.Appointments
                .Include(a => a.LabReports)
                    .ThenInclude(lr => lr.LabTest)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }
    }
}
