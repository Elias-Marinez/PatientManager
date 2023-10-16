
using Microsoft.EntityFrameworkCore;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infrastructure.Persistence.Contexts;

namespace PatientManager.Infrastructure.Persistence.Repositories
{
    public class LabReportRepository : GenericRepository<LabReport>, ILabReportRepository
    {
        private readonly ApplicationContext _dbContext;

        public LabReportRepository(ApplicationContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<List<LabReport>> GetAllWithIncludeAsync()
        {
            return await _dbContext.LabReports
                .Include(lr => lr.LabTest)
                .Include(lr => lr.Appointment)
                    .ThenInclude(appointment => appointment.Patient)
                .ToListAsync();

        }
    }
}
