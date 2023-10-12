
using Microsoft.EntityFrameworkCore;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.ViewModels.User;
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

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            User user = await _dbContext.Set<User>().FirstOrDefaultAsync(user => user.Username == loginVm.Username && user.Password == loginVm.Password);

            return user;
        }
    }
}
