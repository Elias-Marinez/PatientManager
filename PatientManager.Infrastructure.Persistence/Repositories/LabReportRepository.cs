
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

    }
}
