
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infrastructure.Persistence.Contexts;

namespace PatientManager.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
