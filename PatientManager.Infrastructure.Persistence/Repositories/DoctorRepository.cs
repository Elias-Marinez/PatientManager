
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infrastructure.Persistence.Contexts;

namespace PatientManager.Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationContext _dbContext;

        public DoctorRepository(ApplicationContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
