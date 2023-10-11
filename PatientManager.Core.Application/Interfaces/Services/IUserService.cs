
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<UserViewModel, 
                                                    UserSaveViewModel,
                                                    UserUpdateViewModel,
                                                    User>
    {

    }
}
