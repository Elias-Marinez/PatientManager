
using AutoMapper;
using PatientManager.Core.Application.Interfaces.Repository;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Services
{
    public class UserService : GenericService<UserViewModel, UserSaveViewModel, UserUpdateViewModel, User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Login(LoginViewModel vm)
        {
            User user = await _repository.LoginAsync(vm);

            if (user == null)
                return null;

            UserViewModel loginVm = _mapper.Map<UserViewModel>(user);
            return loginVm;
        }
    }
}
