
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infrastructure.Persistence.Contexts;

namespace PatientManager.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationContext _dbContext;

        public PatientRepository(ApplicationContext dbContext) :base(dbContext) 
        {
            _dbContext = dbContext;
        }

    }
}
