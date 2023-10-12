
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Repository
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        Task<User> LoginAsync(LoginViewModel loginVm);
    }
}
