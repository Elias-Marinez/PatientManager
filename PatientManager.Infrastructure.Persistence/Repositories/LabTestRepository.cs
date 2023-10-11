
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infrastructure.Persistence.Contexts;

namespace PatientManager.Infrastructure.Persistence.Repositories
{
    public class LabTestRepository : GenericRepository<LabTest>, ILabTestRepository
    {
        private readonly ApplicationContext _dbContext;

        public LabTestRepository(ApplicationContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
