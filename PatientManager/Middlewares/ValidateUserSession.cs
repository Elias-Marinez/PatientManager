
using PatientManager.Core.Application.Helpers;
using PatientManager.Core.Application.ViewModels.User;

namespace PatientManager.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public bool isLogged()
        {
            UserViewModel vm = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            return (vm != null);
        }

        public bool isAdmin()
        {
            UserViewModel vm = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            return (vm != null && vm.UserType == "Administrador");
        }

        public bool isAsistent()
        {
            UserViewModel vm = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            return (vm != null && vm.UserType == "Asistente");
        }

    }
}
