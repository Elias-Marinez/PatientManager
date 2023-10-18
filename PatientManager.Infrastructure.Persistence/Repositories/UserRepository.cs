
using Microsoft.EntityFrameworkCore;
using PatientManager.Core.Application.Helpers;
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

        public override async Task AddAsync(User entity)
        {
            entity.Password = PasswordEncryptation.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
        }
        public override async Task UpdateAsync(User entity, int id)
        {
            entity.Password = PasswordEncryptation.ComputeSha256Hash(entity.Password);
            await base.UpdateAsync(entity, id);
        }
        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(loginVm.Password);

            User user = await _dbContext.Users
                .FirstOrDefaultAsync(user => user.Username == loginVm.Username && user.Password == passwordEncrypt);

            return user;
        }
        public async Task<bool> ExistsUsername(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == username);
        }
        public async Task<bool> ExistsUsername(string username, int id)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == username && u.UserId != id);
        }
    }
}
