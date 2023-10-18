
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<UserViewModel, 
                                                    UserSaveViewModel,
                                                    UserUpdateViewModel,
                                                    User>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<bool> ExistsUsername(UserSaveViewModel vm);
        Task<bool> ExistsUsername(UserUpdateViewModel vm);
    }
}
